---
title: Por Qué No Automatización
type: docs
weight: 50
url: /java/why-not-automation/
---

{{% alert color="primary" %}} 

Hay dos preguntas que escuchamos con más frecuencia aquí en Aspose: 

La primera es **¿Sus productos requieren que Microsoft Office esté instalado para que funcionen?** 

La respuesta corta y simple es **NO**. Aspose y los componentes de Aspose son totalmente independientes y no están afiliados, ni autorizados, patrocinados o aprobados de ninguna otra manera por Microsoft Corporation. 

La segunda pregunta que típicamente sigue es **¿Por qué deberíamos usar los productos de Aspose en lugar de utilizar Microsoft Office Automation?** 

Esta pregunta no se puede responder tan fácilmente. La respuesta más corta que podríamos dar es que hay muchas razones, siendo la principal que **Microsoft mismo desaconseja fuertemente la Automatización de Office desde soluciones de software** 

{{% /alert %}} 
## **Descripción general**
Como se mencionó anteriormente, hay varias razones por las cuales los componentes de Aspose son una mejor alternativa a la automatización. Algunas de las razones clave son: 

- Seguridad
- Estabilidad
- Escalabilidad/Velocidad
- Precio
- Funcionalidades

A continuación se presenta una mejor elaboración de cada uno de los puntos clave. También asegúrate de visitar la sección de **Información Adicional** que proporciona enlaces a evaluaciones de usuarios independientes. 
## **Seguridad**
Lo siguiente es una cita directa de un artículo de Microsoft: 

*"Las aplicaciones de Office nunca fueron diseñadas para su uso del lado del servidor, y por lo tanto no toman en cuenta los problemas de seguridad que enfrentan los componentes distribuidos. Office no autentica las solicitudes entrantes, y no te protege de ejecutar macros de manera no intencionada, o de iniciar otro servidor que pueda ejecutar macros, desde tu código del lado del servidor. ¡No abras archivos que se suban al servidor desde una Web anónima! Según la configuración de seguridad que se estableció por última vez, el servidor puede ejecutar macros bajo un contexto de Administrador o Sistema con privilegios completos y comprometer tu red. Además, Office utiliza muchos componentes del lado del cliente (como Simple MAPI, WinInet, MSDAIPP) que pueden almacenar en caché la información de autenticación del cliente para acelerar el procesamiento. Si Office se está automatizando del lado del servidor, una instancia puede atender a más de un cliente, y debido a que la información de autenticación se ha almacenado en caché para esa sesión, es posible que un cliente pueda usar las credenciales en caché de otro cliente, y así obtener permisos de acceso no otorgados al hacerse pasar por otros usuarios."* 

Los productos de Aspose son muy seguros. Los componentes de Aspose no suponen un riesgo potencial para los recursos vitales del sistema. Además, cuando un documento es abierto por un componente de Aspose, las macros no se ejecutan automáticamente. Los componentes de Aspose fueron creados con el objetivo de permitir a los desarrolladores crear, manipular y guardar archivos de Office. Ninguno de los riesgos asociados con el paquete de Microsoft Office son inherentes a los componentes de Aspose. 
## **Estabilidad**
Lo siguiente es una cita directa de un artículo de Microsoft: 

*"Office 2000, Office XP y Office 2003 utilizan la tecnología Microsoft Windows Installer (MSI) para facilitar la instalación y la auto-reparación para un usuario final. Los MSI introducen el concepto de "instalar en el primer uso", que permite que las características se instalen o configuren dinámicamente en tiempo de ejecución (para el sistema, o más a menudo para un usuario particular). En un entorno del lado del servidor, esto tanto ralentiza el rendimiento como aumenta la probabilidad de que aparezca un cuadro de diálogo que pida al usuario que apruebe la instalación o proporcione un disco de instalación adecuado. Aunque está diseñado para aumentar la resiliencia de Office como un producto para el usuario final, la implementación de las capacidades de MSI de Office es contraproducente en un entorno del lado del servidor. Además, la estabilidad de Office en general no se puede asegurar cuando se ejecuta del lado del servidor porque no ha sido diseñado ni probado para este tipo de uso. Utilizar Office como un componente de servicio en un servidor de red puede reducir la estabilidad de esa máquina y, como consecuencia, de tu red en su totalidad. Si planeas automatizar Office del lado del servidor, intenta aislar el programa en una computadora dedicada que no pueda afectar funciones críticas, y que pueda reiniciarse según sea necesario."* 

Los componentes de Aspose han sido rigurosamente probados y son extremadamente estables. Los componentes de Aspose son utilizados por [Empresas](https://about.aspose.com/customers) como: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** y muchas más. 
## **Escalabilidad/Velocidad**
Lo siguiente es una cita directa de un artículo de Microsoft: 

*"Los componentes del lado del servidor necesitan ser componentes COM de múltiples hilos altamente reentrantes con un mínimo de sobrecarga y un alto rendimiento para múltiples clientes. Las aplicaciones de Office son en casi todos los aspectos lo contrario exacto. Son servidores de automatización basados en STA no reentrantes que están diseñados para proporcionar funcionalidad diversa pero intensiva en recursos para un solo cliente. Ofrecen poca escalabilidad como solución del lado del servidor, y tienen límites fijos en elementos importantes, como la memoria, que no se pueden cambiar a través de la configuración. Más importante aún, utilizan recursos globales (como archivos mapeados en memoria, complementos o plantillas globales, y servidores de automatización compartidos), lo que puede limitar la cantidad de instancias que pueden ejecutarse simultáneamente y provocar condiciones de carrera si están configuradas en un entorno multi-cliente. Los desarrolladores que planean ejecutar más de una instancia de cualquier aplicación de Office al mismo tiempo deben considerar* ***Agrupamiento*** *o* ***Acceso Serializado*** *a la aplicación de Office para evitar posibles* ***Bloqueos*** *o* ***Corrupción de Datos*** .* 

Los componentes de Aspose son altamente escalables y extremadamente rápidos. Las aplicaciones de Office no fueron diseñadas para ser utilizadas simultáneamente por cientos y miles de usuarios. Sin embargo, los componentes de Aspose están diseñados precisamente para eso. Nuestros componentes funcionan a la perfección, ya sea en un solo servidor, alimentando una única aplicación o en un formulario web equilibrado que alimenta una aplicación extensa. 
## **Precio**
Cuando una aplicación utiliza Microsoft Office Automation, se debe comprar una copia de Microsoft Office para cada máquina que ejecute la aplicación. Muchas veces, una aplicación puede necesitar crear o manipular un archivo de Office pero no requiere que el usuario tenga Microsoft Office. Aspose ofrece una licencia de [Redistribución Sin Regalías](https://purchase.aspose.com/) que permite el despliegue a un número ilimitado de usuarios sin preocupaciones de licencias. 

Al crear aplicaciones basadas en la web, es importante saber que los componentes de Microsoft Office Automation no están precios ni licenciados para soluciones del lado del servidor; por lo tanto, no existe una buena solución de licencias para desplegar aplicaciones web que utilicen los componentes de Microsoft Office. Aspose también ofrece una solución muy costo-efectiva para aplicaciones basadas en servidores. 
## **Características**
Los componentes de Aspose proporcionan todo lo necesario para gestionar archivos de Office, además de mucho más. Están diseñados con la filosofía de permitir a los desarrolladores lograr los mejores resultados con la menor cantidad de trabajo. A diferencia de la automatización de Office, los componentes de Aspose ofrecen muchas funciones poderosas y que ahorran tiempo. Por ejemplo, [Aspose.Cells](https://products.aspose.com/cells/java/) ofrece a los desarrolladores la capacidad de importar datos desde un **DataTable** o **DataView** directamente en un archivo de Excel. [Aspose.Words](https://products.aspose.com/words/java/) ofrece una característica similar que permite a los desarrolladores llenar un documento de Word (que es una combinación de correspondencia). [Cada Componente](https://products.aspose.com/total/java/) en la familia Aspose ofrece su propio conjunto de características únicas y poderosas. 

La mejor parte de comprar un componente de Aspose (o suites de componentes como [Aspose.Total](https://products.aspose.com/total/java/)) es tener acceso a nuestros equipos de desarrollo. Nuestros equipos de desarrollo se dan cuenta de que si hay una característica que necesita tu empresa, muy probablemente otras empresas también la necesitarán. Si bien no todas las solicitudes de funciones pueden ser añadidas, nuestros equipos tratan de ser muy abiertos y flexibles al proporcionar asistencia. Esa mentalidad es lo que ha permitido a los componentes de Aspose volverse tan poderosos como son. Si necesitas características adicionales de los objetos de automatización de Office, tus posibilidades de que se agreguen son muy, muy bajas. 
## **Conclusión**
{{% alert color="primary" %}} 

Si bien este artículo ha cubierto muchos de los puntos clave por los cuales los componentes de Aspose son una mejor opción que la automatización de Office, hay muchos, muchos más. Este artículo aborda principalmente solo los puntos más clave. Todos los diferentes componentes de Aspose ofrecen una versión de [Evaluación](https://downloads.aspose.com/slides/java) sin riesgo y sin obligación. Te animamos a que aproveches esa evaluación para ver mejor lo que Aspose puede hacer por tus aplicaciones. 

{{% /alert %}} 