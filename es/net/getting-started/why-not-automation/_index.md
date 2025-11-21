---
title: "¿Por qué no automatizar?"
type: docs
weight: 40
url: /es/net/why-not-automation/
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
- .NET
- C#
- Aspose.Slides
description: "Descubra por qué la automatización de Office es arriesgada para servidores y servicios, y vea cómo Aspose.Slides ofrece un procesamiento de presentaciones más seguro y rápido para PowerPoint y OpenDocument."
---

## **Preguntas importantes**
- ¿Por qué los componentes de Aspose son una opción mucho mejor que la Automatización de Microsoft Office?

Hay dos preguntas que escuchamos a menudo en Aspose:

- ¿Sus productos requieren que Microsoft Office esté instalado para poder ejecutarse?

La respuesta corta y simple—**NO**. 

Aspose y los componentes de Aspose son totalmente independientes y no están afiliados, ni autorizados, patrocinados o de otro modo aprobados por Microsoft Corporation.

- ¿Por qué deberíamos usar los productos de Aspose en lugar de utilizar la Automatización de Microsoft Office?

Por una parte, existen muchos [beneficios que obtiene al usar Aspose.Slides](https://docs.aspose.com/slides/net/product-overview/). 

Por otra parte, Microsoft mismo **desaconseja** el uso de la Automatización de Office en soluciones de software. 

## **Visión general**
Como afirmamos anteriormente, hay varias razones por las que los componentes de Aspose son una mejor alternativa a la automatización. Algunas de las razones principales son:

- Seguridad
- Estabilidad
- Escalabilidad/Velocidad
- Precio
- Características

Ampliamos las razones clave en los párrafos siguientes. 
## **Seguridad**
A continuación se muestra una cita directa de un artículo de Microsoft:

> Las aplicaciones de Office nunca fueron diseñadas para usarse del lado del servidor, por lo que no consideran los problemas de seguridad que enfrentan los componentes distribuidos. Office no autentica las solicitudes entrantes y no lo protege de ejecutar macros involuntariamente, o de iniciar otro servidor que pueda ejecutar macros, desde su código del lado del servidor. ¡No abra archivos que se cargan al servidor desde la web de forma anónima! Según la configuración de seguridad establecida por última vez, el servidor puede ejecutar macros bajo el contexto de Administrador o Sistema con todos los privilegios y comprometer su red. Además, Office utiliza muchos componentes del lado del cliente (como Simple MAPI, WinInet, MSDAIPP) que pueden almacenar en caché la información de autenticación del cliente para acelerar el procesamiento. Si Office se automatiza del lado del servidor, una instancia puede atender a más de un cliente y, dado que la información de autenticación ha sido almacenada en caché para esa sesión, es posible que un cliente use las credenciales en caché de otro cliente, obteniendo así permisos de acceso no concedidos al suplantar a otros usuarios.

Los productos de Aspose son muy **seguros**. Los componentes de Aspose se ejecutan en el mismo contexto de usuario que todas las aplicaciones ASP.NET (bajo el usuario ASPNET). Por lo tanto, los componentes de Aspose **no** representan un riesgo de seguridad. Tampoco consumen recursos críticos del sistema. Además, cuando un componente de Aspose abre un documento, las macros no se ejecutan automáticamente. Los componentes de Aspose fueron creados para permitir a los desarrolladores crear, manipular y guardar archivos de Office.

{{% alert color="primary" %}} 

Ninguno de los riesgos asociados con el paquete Microsoft Office se aplica a los componentes de Aspose.

{{% /alert %}} 

## **Estabilidad**
Este texto es una cita directa del artículo de Microsoft mencionado anteriormente:

> Office 2000, Office XP y Office 2003 utilizan la tecnología Microsoft Windows Installer (MSI) para facilitar la instalación y la autorreparación al usuario final. MSI introduce el concepto de “instalar en el primer uso”, que permite que las funciones se instalen o configuren dinámicamente en tiempo de ejecución (para el sistema, o más a menudo para un usuario específico). En un entorno del lado del servidor, esto tanto reduce el rendimiento como aumenta la probabilidad de que aparezca un cuadro de diálogo que solicite al usuario aprobar la instalación o proporcionar un disco de instalación adecuado. Aunque está diseñado para aumentar la resiliencia de Office como producto para el usuario final, la implementación de las capacidades MSI por parte de Office es contraproducente en un entorno del lado del servidor. Además, la estabilidad de Office en general no puede garantizarse cuando se ejecuta del lado del servidor porque no ha sido diseñado o probado para este tipo de uso. Usar Office como componente de servicio en un servidor de red puede reducir la estabilidad de esa máquina y, como consecuencia, de toda su red. Si planea automatizar Office del lado del servidor, intente aislar el programa en una computadora dedicada que no pueda afectar funciones críticas y que pueda reiniciarse según sea necesario.

Dado que los componentes de Aspose se empaquetan en una única DLL, sus usuarios nunca necesitan instalar partes o piezas adicionales para que funcionen. Los componentes de Aspose solo son utilizados por aplicaciones .NET y no existe ninguna parte del código del componente diseñada para esperar una respuesta humana. 

{{% alert color="primary" %}} 

Los componentes de Aspose han sido probados exhaustivamente y se ha confirmado que son muy estables. Los componentes de Aspose son utilizados por [empresas](http://www.aspose.com/Corporate/Aspose/Customerlist.html) como **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, y muchas otras organizaciones líderes en varios sectores e industrias. 

{{% /alert %}} 

## **Escalabilidad/Velocidad**
A continuación se muestra una cita directa de un artículo de Microsoft:

> Los componentes del lado del servidor necesitan ser componentes COM altamente reentrantes y multihilo, con un overhead mínimo y un alto rendimiento para múltiples clientes. Las aplicaciones de Office son, en casi todos los aspectos, exactamente lo contrario. Son servidores de Automatización basados en STA, no reentrantes, diseñados para proporcionar funcionalidades diversas pero intensivas en recursos para un solo cliente. Ofrecen poca escalabilidad como solución del lado del servidor y tienen límites fijos en elementos importantes, como la memoria, que no pueden modificarse mediante configuración. Más importante aún, utilizan recursos globales (como archivos mapeados en memoria, complementos o plantillas globales y servidores de Automatización compartidos), lo que puede limitar el número de instancias que pueden ejecutarse simultáneamente y generar condiciones de carrera si se configuran en un entorno de múltiples clientes. Los desarrolladores que planeen ejecutar más de una instancia de cualquier aplicación de Office al mismo tiempo deben considerar el agrupamiento o la serialización del acceso a la aplicación de Office para evitar posibles bloqueos (deadlocks) o corrupción de datos.

Los componentes de Aspose son increíblemente escalables y ultrarrápidos. Las aplicaciones de Office no fueron diseñadas para ser usadas simultáneamente por cientos o miles de usuarios, pero los componentes de Aspose están diseñados precisamente para eso. Nuestros componentes son una solución .NET verdadera. 

{{% alert color="primary" %}} 

El rendimiento de los componentes de Aspose es impecable en un solo servidor (potenciando una única aplicación) o en un formulario web balanceado (potenciando una aplicación a nivel empresarial).

{{% /alert %}} 

## **Precio**
Cuando una aplicación utiliza la Automatización de Microsoft Office, se debe adquirir una copia de Microsoft Office para cada máquina que ejecuta la aplicación. Hay muchas instancias en que una aplicación necesita crear o manipular un archivo de Office, pero el proceso no requiere Microsoft Office. 

{{% alert color="primary" %}} 

Aspose ofrece una licencia de redistribución muy [rentable](https://purchase.aspose.com/) y libre de regalías que permite el despliegue a un número ilimitado de usuarios sin preocupaciones de licenciamiento. 

{{% /alert %}} 

Al crear aplicaciones web, es importante recordar que los componentes de Automatización de Microsoft Office no tienen precio ni licencia para soluciones del lado del servidor. Por lo tanto, no existe una solución de licenciamiento adecuada para el despliegue de aplicaciones web que utilicen componentes de Microsoft Office. Aspose, por otro lado, ofrece una solución muy [rentable](https://purchase.aspose.com/) también para aplicaciones basadas en servidor. 

## **Características**
Los componentes de Aspose proporcionan todo lo necesario para gestionar archivos de Office y mucho más. Los diseñamos basándonos en nuestra filosofía de ayudar a los desarrolladores a lograr los mejores resultados posibles con el menor esfuerzo. 

{{% alert color="primary" %}} 

A diferencia de la Automatización de Office, los componentes de Aspose ofrecen muchas funciones potentes y que ahorran tiempo. 

{{% /alert %}} 

Por ejemplo, [Aspose.Cells](https://products.aspose.com/cells/net/) brinda a los desarrolladores la capacidad de importar datos desde una **DataTable** o **DataView** directamente a un archivo Excel. [Aspose.Words](https://products.aspose.com/words/net/) ofrece una característica similar que permite a los desarrolladores rellenar un documento Word (es decir, combinación de correspondencia) directamente a partir de cualquier objeto de datos .NET. [Every component](https://products.aspose.com/total/net/) en la familia Aspose ofrece su propio conjunto de características únicas y potentes. 

La mejor parte de adquirir un componente de Aspose es obtener acceso a nuestros equipos de desarrollo. Por ejemplo, si usa objetos de Automatización de Office y necesita ciertas funciones, las probabilidades de que esas funciones se agreguen son muy, muy bajas. Sin embargo, las cosas son diferentes con los componentes de Aspose. 

{{% alert color="primary" %}} 

Nuestros equipos de desarrollo comprenden que si hay una característica que su empresa necesita, es probable que otras empresas también la necesiten. Aunque sabemos que no podemos implementar todas las características solicitadas, nos esforzamos por añadir tantas como sea posible basándonos en los comentarios de nuestros clientes. 

{{% /alert %}} 

Nuestros equipos están siempre abiertos y son flexibles al brindar asistencia, y esta es la razón por la que los componentes de Aspose han llegado a ser tan poderosos como son hoy. 

## **Conclusión**
{{% alert color="primary" %}} 

Aunque este artículo cubrió algunos de los puntos clave de por qué los componentes de Aspose son una mejor opción que la Automatización de Office, debe entender que existen muchos, muchos más beneficios. Solo revisamos algunas de las principales ventajas.

Además, todos los productos y componentes de Aspose ofrecen una [Versión de Evaluación](https://downloads.aspose.com/slides/net) sin riesgos y sin obligación. Le animamos a aprovechar la evaluación para ver lo que Aspose puede hacer por sus aplicaciones o su negocio. 

{{% /alert %}}