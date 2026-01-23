---
title: Por qué no la automatización
type: docs
weight: 50
url: /es/php-java/why-not-automation/
keywords:
- automatización
- Microsoft Office
- comparación
- seguridad
- estabilidad
- escalabilidad
- características
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Descubra por qué la automatización de Office es arriesgada para servidores y servicios, y vea cómo Aspose.Slides ofrece un procesamiento de presentaciones más seguro y rápido para PowerPoint y OpenDocument."
---

{{% alert color="primary" %}} 

Hay dos preguntas que escuchamos con mayor frecuencia aquí en Aspose: 

La primera es **¿Requieren sus productos que Microsoft Office esté instalado para poder ejecutarse?** 

La respuesta corta y simple es **NO**. Aspose y sus componentes son totalmente independientes y no están afiliados, autorizados, patrocinados ni aprobados de ninguna manera por Microsoft Corporation. 

La segunda pregunta que suele seguir es **¿Por qué deberíamos usar los productos Aspose en lugar de utilizar la automatización de Microsoft Office?** 

Esta pregunta no se puede responder tan fácilmente. La respuesta más breve que podemos dar es que hay muchas razones, siendo la principal que **Microsoft mismo recomienda encarecidamente no usar la automatización de Office en soluciones de software** 

{{% /alert %}} 
## **Visión general**
Como se indicó anteriormente, hay varias razones por las que los componentes Aspose son una alternativa mejor a la automatización. Algunas de las razones clave son: 

- Seguridad
- Estabilidad
- Escalabilidad/Velocidad
- Precio
- Funcionalidades

A continuación una mayor elaboración de cada uno de los puntos clave. También asegúrese de visitar la sección **Información adicional** que proporciona enlaces a evaluaciones independientes de usuarios. 
## **Seguridad**
A continuación una cita directa de un artículo de Microsoft: 

*"Las aplicaciones de Office nunca fueron diseñadas para usarse del lado del servidor, y por lo tanto no consideran los problemas de seguridad a los que se enfrentan los componentes distribuidos. Office no autentica las solicitudes entrantes, y no le protege de ejecutar macros inadvertidamente, o de iniciar otro servidor que pueda ejecutar macros, desde su código del lado del servidor. ¡No abra archivos que se carguen al servidor desde la web de forma anónima! Según la configuración de seguridad establecida por última vez, el servidor puede ejecutar macros bajo el contexto de Administrador o Sistema con privilegios completos y comprometer su red. Además, Office utiliza muchos componentes del lado del cliente (como Simple MAPI, WinInet, MSDAIPP) que pueden almacenar en caché información de autenticación del cliente para acelerar el procesamiento. Si Office se automatiza del lado del servidor, una instancia puede atender a más de un cliente, y como la información de autenticación se ha almacenado en caché para esa sesión, es posible que un cliente use las credenciales en caché de otro cliente, obteniendo así permisos de acceso no concedidos al hacerse pasar por otros usuarios."* 

Los productos Aspose son muy seguros. Los componentes Aspose no representan un riesgo potencial para los recursos críticos del sistema. Además, cuando un documento es abierto por un componente Aspose, las macros no se ejecutan automáticamente. Los componentes Aspose fueron construidos con el objetivo de permitir a los desarrolladores crear, manipular y guardar archivos de Office. Ninguno de los riesgos asociados con el paquete Microsoft Office es inherente a los componentes Aspose. 
## **Estabilidad**
A continuación una cita directa de un artículo de Microsoft: 

*"Office 2000, Office XP y Office 2003 utilizan la tecnología Microsoft Windows Installer (MSI) para facilitar la instalación y la autorreparación al usuario final. MSI introduce el concepto de “instalar en el primer uso”, que permite que las funcionalidades se instalen o configuren dinámicamente en tiempo de ejecución (para el sistema o, más a menudo, para un usuario concreto). En un entorno del lado del servidor esto ralentiza el rendimiento y aumenta la probabilidad de que aparezca un cuadro de diálogo que solicite al usuario aprobar la instalación o proporcionar un disco de instalación adecuado. Aunque está diseñado para aumentar la resiliencia de Office como producto para el usuario final, la implementación de las capacidades MSI por parte de Office es contraproducente en un entorno del lado del servidor. Además, no se puede garantizar la estabilidad de Office en general cuando se ejecuta del lado del servidor porque no ha sido diseñado ni probado para este tipo de uso. Utilizar Office como componente de servicio en un servidor de red puede reducir la estabilidad de esa máquina y, como consecuencia, la de toda su red. Si planea automatizar Office del lado del servidor, intente aislar el programa en un equipo dedicado que no pueda afectar funciones críticas y que pueda reiniciarse según sea necesario."* 

Los componentes Aspose han sido probados exhaustivamente y son extremadamente estables. Los componentes Aspose son utilizados por [Empresas](https://about.aspose.com/customers) como: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** y muchas, muchas más. 
## **Escalabilidad/Velocidad**
A continuación una cita directa de un artículo de Microsoft: 

*"Los componentes del lado del servidor necesitan ser altamente reentrantes, componentes COM multihilo con el mínimo sobrecoste y alto rendimiento para múltiples clientes. Las aplicaciones de Office son, en casi todos los aspectos, lo contrario exacto. Son servidores de automatización basados en STA, no reentrantes, diseñados para proporcionar funcionalidades diversas pero intensivas en recursos para un solo cliente. Ofrecen poca escalabilidad como solución del lado del servidor y tienen límites fijos en elementos importantes, como la memoria, que no pueden modificarse mediante configuración. Además, utilizan recursos globales (como archivos mapeados en memoria, complementos o plantillas globales y servidores de automatización compartidos), lo que puede limitar el número de instancias que pueden ejecutarse simultáneamente y provocar condiciones de carrera si se configuran en un entorno multi‑cliente. Los desarrolladores que planifiquen ejecutar más de una instancia de cualquier aplicación de Office al mismo tiempo deben considerar* ***Pooling*** *o* ***Serializing Access*** *a la aplicación de Office para evitar posibles* ***Deadlocks*** *o* ***Data Corruption*** *.*"* 

Los componentes Aspose son altamente escalables y extremadamente rápidos. Las aplicaciones de Office no fueron diseñadas para ser usadas simultáneamente por cientos o miles de usuarios. Sin embargo, los componentes Aspose están diseñados precisamente para eso. Nuestros componentes funcionan sin problemas tanto en un único servidor que alimenta una sola aplicación como en un formulario web balanceado que impulsa una aplicación empresarial de gran escala. 
## **Precio**
Cuando una aplicación utiliza la automatización de Microsoft Office, se debe comprar una copia de Microsoft Office para cada máquina que ejecuta la aplicación. En muchas ocasiones una aplicación necesita crear o manipular un archivo de Office pero no requiere que el usuario tenga Microsoft Office. Aspose ofrece una licencia de redistribución muy [rentable](https://purchase.aspose.com/) y sin royalties que permite el despliegue a un número ilimitado de usuarios sin preocupaciones de licencias. 

Al crear aplicaciones web es importante saber que los componentes de automatización de Microsoft Office no tienen precios ni licencias para soluciones del lado del servidor; por lo tanto, no existe una solución de licenciamiento adecuada para desplegar aplicaciones web que utilicen los componentes de Microsoft Office. Aspose también ofrece una solución muy rentable para aplicaciones basadas en servidor. 
## **Funcionalidades**
Los componentes Aspose proporcionan todo lo necesario para gestionar archivos de Office y mucho más. Están diseñados con la filosofía de permitir a los desarrolladores lograr los mejores resultados con el menor esfuerzo. A diferencia de la automatización de Office, los componentes Aspose ofrecen muchas funciones potentes y que ahorran tiempo. Por ejemplo, [Aspose.Cells](https://products.aspose.com/cells/php-java/) brinda a los desarrolladores la capacidad de importar datos de una **DataTable** o **DataView** directamente a un archivo Excel. [Cada componente](https://products.aspose.com/total/php-java/) de la familia Aspose ofrece su propio conjunto de características únicas y potentes. 

La mejor parte de comprar un componente Aspose (o suites de componentes como [Aspose.Total](https://products.aspose.com/total/php-java/)) es tener acceso a nuestros equipos de desarrollo. Nuestros equipos de desarrollo comprenden que si hay una característica que su empresa necesita, es muy probable que otras empresas también la necesiten. Aunque no todas las solicitudes de características pueden ser añadidas, nuestros equipos tratan de ser muy abiertos y flexibles al proporcionar asistencia. Esa mentalidad es la que ha ayudado a que los componentes Aspose se vuelvan tan poderosos. Si hay características adicionales que necesita de los objetos de automatización de Office, sus posibilidades de que se añadan son muy, muy bajas. 
## **Conclusión**
{{% alert color="primary" %}} 

Si bien este artículo ha cubierto muchos de los puntos clave por los que los componentes Aspose son una mejor elección que la automatización de Office, hay muchos, muchos más. Este artículo solo aborda los puntos más importantes. Todos los diferentes componentes Aspose ofrecen una [Versión de Evaluación](https://downloads.aspose.com/slides/java) sin riesgo y sin obligación. Le animamos a aprovechar esa evaluación para ver mejor lo que Aspose puede hacer por sus aplicaciones. 

{{% /alert %}}