---
title: Cómo ejecutar tareas en segundo plano en ASP.NET Core
type: docs
weight: 300
url: /es/net/how-to-run-background-tasks-in-asp-net-core/
---

## **Resumen**
El procesamiento de archivos (por ejemplo, exportar una presentación a PDF) es una tarea típica del lado del servidor. El procesamiento simple de archivos dentro del controlador de solicitudes (cuando el cliente está esperando mientras el servidor realiza el trabajo) tiene las siguientes desventajas:

- *Mal UI*. La página se congela y el usuario tiene que esperar el resultado. La recarga de la página cancelará la tarea.
- *Tiempo de espera de la operación*. No podemos garantizar que el procesamiento se complete en un período de tiempo fijo, lo que significa que el usuario verá "tiempo de espera de la operación" tarde o temprano.
- *Bajo rendimiento y escalabilidad*. ASP.NET Core está diseñado para procesar muchas solicitudes de manera asincrónica. Las tareas de larga duración que consumen CPU bloquean los hilos y reducen el rendimiento del servidor.
- *Mala tolerancia a fallos*. Cuando algo sale mal en medio de una tarea de larga duración (por ejemplo, un problema de conectividad), el procesamiento simplemente falla y tenemos que reiniciar el procesamiento desde el principio una vez más.

Un[ enfoque mejor](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices#complete-long-running-tasks-outside-of-http-requests) es programar el trabajo de manera asincrónica primero, completarlo en segundo plano segundo y devolver el resultado del procesamiento por último.

En este caso, el usuario puede ver el estado actual (e incluso salir o recargar la página), los recursos del servidor pueden escalarse de manera eficiente y ajustarse flexible y adecuadamente. También se puede utilizar una política de reintento.

Por lo tanto, la solución típica de procesamiento en segundo plano incluye las siguientes partes:
1. API para programar el trabajo.
2. API para rastrear el estado del trabajo.
3. El trabajador en segundo plano para procesar los trabajos programados.
4. API para almacenar/obtener el resultado.


## **Ejemplo de Tarea en Segundo Plano**
Para demostrar este enfoque, consideremos el [**ejemplo de aplicación web ASP.NET Core 3.1**](https://wiki.lutsk.dynabic.com/download/Aspose%20Slides/slidesnet/Discussion%20on%20Russian/Issues/Platform%20specific/How%20to%20run%20Background%20Tasks%20in%20ASP.NET%20Core/WebHome/BackgroundJobDemo.zip?rev=1.1). La aplicación web contiene una página web, donde el usuario puede subir la presentación, presionar el botón "Exportar a PDF", luego la presentación será cargada y convertida a formato PDF por un trabajador en segundo plano.
## **Aplicación Web**
La aplicación web de ejemplo (*BackgroundJobDemo* proyecto) incluye:

- Página de carga de archivos (página razor Carga).
- Página de progreso (página razor Progreso con algunas funciones de JavaScript que verifican y muestran el estado).
- Controlador (JobStatusController) que proporciona el estado de procesamiento (api/status/{jobId}).
- Controlador (JobResultController) que devuelve el archivo PDF exportado (api/result/{id}).
- Trabajador en segundo plano basado en el servicio de alojamiento de ASP.NET Core (ver clase WorkerService).

Las páginas Razor, los controladores y el trabajador en segundo plano delegan todo el trabajo real a través de interfaces, definidas en *BackgroundJobDemo.Common* proyecto. Las implementaciones concretas de la gestión y procesamiento de trabajos se definen en proyectos separados (*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws* etc) y pueden ser fácilmente cambiadas en el método Startup.ConfigureServices.

Para fines de demostración, la página "Cargar" utiliza el enlace de modelo basado en búfer, pero para la carga de archivos grandes se recomienda [streaming sin búfer](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads). Para el despliegue en producción, se deben tener en cuenta los [aspectos de seguridad](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations). La página "Progreso" consulta el estado del trabajo programado a través de JavaScript cada 2 segundos (el período puede ser modificado). La consulta del estado es un comportamiento típico, pero para casos avanzados, las notificaciones en tiempo real (las comunicaciones en tiempo real están fuera del alcance de este artículo) a través de WebSocket pueden ser requeridas. [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) es una herramienta simple pero poderosa para las comunicaciones en tiempo real.

El alojamiento del trabajador en segundo plano en el proceso del servidor es conveniente para aplicaciones simples, pero tiene [desventajas](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx). La solución más robusta y escalable es desplegar el trabajador en un proceso separado (ver, por ejemplo, *BackgroundJobDemo.Worker* aplicación de consola). 
## **Implementación Básica**
El proyecto *BackgroundJobDemo.Local* contiene una implementación simple de gestión de trabajos con base de datos SQLite (la ruta al archivo de base de datos se especifica a través de LocalConfig.DbFilePath, ver en Startup.ConfigureServices). Los archivos cargados y procesados se almacenan en el sistema de archivos (la ruta a la carpeta de almacenamiento se especifica a través de LocalConfig.FileStorageFolderPath, ver en Startup.ConfigureServices). Para una mejor tolerancia a fallos y rendimiento en aplicaciones del mundo real, la programación de trabajos debería implementarse a través de colas de mensajes (por ejemplo, RabbitMQ, AWS SQS, Azure Storage Queue).
## **Implementación Distribuida Basada en Amazon Web Services**
El proyecto *BackgroundJobDemo.Aws* implementa el procesamiento de trabajos a través de Amazon Web Services y demuestra la arquitectura distribuida que puede escalar horizontalmente. Incluye los siguientes componentes:

- Aplicación web - interactúa con el usuario y programa las tareas de exportación de PPTX a PDF, etc.
- Trabajador - procesa la exportación (en proceso, fuera de proceso o Amazon Lambda).
- Cola de mensajes - almacena las tareas a procesar (Amazon SQS).
- Almacenamiento de archivos - guarda los archivos cargados y procesados (Amazon S3).
- Almacenamiento de clave-valor - proporciona el estado del procesamiento de tareas (Amazon DynamoDB). 

La arquitectura distribuida típica se basa en [colas de mensajes](https://aws.amazon.com/message-queue/): la aplicación web coloca las tareas en segundo plano en la cola, el trabajador en segundo plano toma la tarea de la cola y realiza el trabajo requerido. Por lo tanto, los componentes del sistema (la aplicación web y el trabajador en segundo plano) están desacoplados y el procesamiento es asincrónico y confiable. La cola garantiza que todos los mensajes (tareas) se entreguen a los trabajadores. Los mensajes de la cola tienen *tiempo de visibilidad* - cuando un trabajador recibe el mensaje para su procesamiento, el mensaje se vuelve invisible para otros trabajadores y solo el trabajador que procesa el mensaje lo elimina de la cola. Si el procesamiento no se completa durante el tiempo de visibilidad (por ejemplo, falla o problema de red), el mensaje no procesado vuelve a ser visible para los trabajadores nuevamente.

Nuestra implementación utiliza [Amazon Simple Queue Service](https://aws.amazon.com/sqs/) (SQS) - colas de mensajes completamente administradas para microservicios, sistemas distribuidos y aplicaciones sin servidor.

Las colas de mensajes están diseñadas para mensajes ligeros (por ejemplo, el límite de tamaño de un mensaje SQS es de 256 KB), por lo que solo deben contener la descripción de la tarea. Todos los datos pesados (por ejemplo, archivos a procesar) deben colocarse en el almacenamiento separado y ser referenciados desde el mensaje. [Amazon S3](https://aws.amazon.com/s3/) es un almacenamiento de objetos diseñado para almacenar y recuperar cualquier cantidad de datos desde cualquier lugar. Este servicio se utiliza para almacenar archivos cargados y procesados.

Se requiere almacenamiento de clave-valor para almacenar y recuperar el resultado del procesamiento del trabajo por ID. [Amazon DynamoDB](https://aws.amazon.com/dynamodb/) (servicio de base de datos NoSQL rápido y flexible para cualquier escala) se utilizó en el ejemplo.

Para ejecutar la aplicación de demostración con Amazon Web Services:

1. Crea y configura en la misma región de AWS:
   1. Cola SQS,
   1. Cubo S3,
   1. Tabla DynamoDB.
1. Conecta la aplicación web a los servicios creados con el método de extensión AddAws (URL de cola SQS, nombre del cubo S3, nombre de la tabla DynamoDB y región de AWS) desde Startup.ConfigureServices. 
## **Referencias**
- Mejores Prácticas de Rendimiento de ASP.NET Core <https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices>
- Subir archivos en ASP.NET Core <https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads>
- ASP.NET en tiempo real con SignalR <https://dotnet.microsoft.com/apps/aspnet/signalr>
- Colas de Mensajes <https://aws.amazon.com/message-queue/>
- Servicio de Cola Simple de Amazon <https://aws.amazon.com/sqs/>
- Amazon S3 <https://aws.amazon.com/s3/>
- Amazon DynamoDB <https://aws.amazon.com/dynamodb/>