---
title: Por qué no usar automatización
type: docs
weight: 170
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
## **Introducción**

Hay varias razones por las que los componentes de Aspose son una alternativa mejor que la automatización. Algunas de las razones clave son:

- Seguridad
- Estabilidad
- Escalabilidad/Velocidad
- Precio
- Características

A continuación encontrarás una explicación más detallada de cada punto clave.

## **Preguntas importantes**

Hay dos preguntas que escuchamos con frecuencia en Aspose:

- ¿Requieren sus productos que Microsoft Office esté instalado para poder ejecutarse?

La respuesta corta y simple es **NO**.

Los componentes de Aspose son completamente independientes y no están afiliados, autorizados, patrocinados ni aprobados de ninguna manera por Microsoft Corporation.

- ¿Por qué deberíamos usar los productos de Aspose en lugar de la Automatización de Microsoft Office?

Primero, hay muchos [beneficios que obtienes al usar Aspose.Slides](/slides/es/net/product-overview/).

En segundo lugar, Microsoft mismo aconseja firmemente **no usar** la Automatización de Office desde soluciones de software.

## **Seguridad**
A continuación se muestra una cita directa de un artículo de Microsoft:

> Las aplicaciones de Office nunca fueron diseñadas para usarse del lado del servidor, y por lo tanto no consideran los problemas de seguridad que enfrentan los componentes distribuidos. Office no autentica las solicitudes entrantes y no lo protege de ejecutar macros de forma involuntaria, o de iniciar otro servidor que pueda ejecutar macros, desde su código del lado del servidor. ¡No abra archivos que se hayan subido al servidor desde la Web de forma anónima! Según la configuración de seguridad establecida por última vez, el servidor puede ejecutar macros bajo un contexto de Administrador o Sistema con privilegios completos y comprometer su red. Además, Office utiliza muchos componentes del lado del cliente (como Simple MAPI, WinInet, MSDAIPP) que pueden almacenar en caché información de autenticación del cliente para acelerar el procesamiento. Si Office se automatiza del lado del servidor, una instancia puede atender a más de un cliente y, dado que la información de autenticación se ha almacenado en caché para esa sesión, es posible que un cliente utilice las credenciales almacenadas de otro cliente y así obtenga permisos de acceso no concedidos al impersonar a otros usuarios.

Los productos de Aspose son muy **seguros**. Los componentes de Aspose se ejecutan en el mismo contexto de usuario que todas las aplicaciones ASP.NET (bajo el usuario ASPNET). Por lo tanto, los componentes de Aspose **no** representan un riesgo de seguridad. Además, no consumen recursos críticos del sistema. Además, cuando un componente de Aspose abre un documento, las macros no se ejecutan automáticamente. Los componentes de Aspose fueron creados para permitir a los desarrolladores crear, manipular y guardar archivos de Office.

{{% alert color="info" title="Note" %}}
Ninguno de los riesgos asociados con el paquete Microsoft Office se aplican a los componentes de Aspose.
{{% /alert %}}

## **Estabilidad**
Este texto es una cita directa del artículo de Microsoft mencionado anteriormente:

> Office 2000, Office XP y Office 2003 utilizan la tecnología Microsoft Windows Installer (MSI) para facilitar la instalación y la autorreparación al usuario final. MSI introduce el concepto de “instalar al primer uso”, que permite que las funciones se instalen o configuren dinámicamente en tiempo de ejecución (para el sistema, o más a menudo para un usuario específico). En un entorno del lado del servidor, esto ralentiza el rendimiento y aumenta la probabilidad de que aparezca un cuadro de diálogo que solicite al usuario aprobar la instalación o proporcionar un disco de instalación adecuado. Aunque está diseñado para aumentar la resiliencia de Office como producto de usuario final, la implementación de las capacidades MSI por parte de Office es contraproducente en un entorno del lado del servidor. Además, la estabilidad de Office en general no puede garantizarse cuando se ejecuta del lado del servidor porque no ha sido diseñado ni probado para este tipo de uso. Usar Office como componente de servicio en un servidor de red puede reducir la estabilidad de esa máquina y, como consecuencia, de toda la red. Si planea automatizar Office del lado del servidor, intente aislar el programa en un equipo dedicado que no pueda afectar funciones críticas y que pueda reiniciarse según sea necesario.

Como los componentes de Aspose se empaquetan en un único DLL, sus usuarios nunca necesitan instalar partes o piezas adicionales para que funcionen. Los componentes de Aspose solo son utilizados por aplicaciones .NET y no hay ninguna parte del código del componente diseñada para esperar una respuesta humana.

{{% alert color="info" title="Note" %}}
Los componentes de Aspose han sido probados exhaustivamente y se ha confirmado que son muy estables. Los componentes de Aspose son utilizados por [empresas](https://about.aspose.com/customers/) como **Bank of America** y muchas otras organizaciones líderes en varios sectores y campos.
{{% /alert %}}

## **Escalabilidad/Velocidad**
A continuación se muestra una cita directa de un artículo de Microsoft:

> Los componentes del lado del servidor necesitan ser componentes COM altamente reentrantes y multihilo, con una sobrecarga mínima y un alto rendimiento para múltiples clientes. Las aplicaciones de Office son, en casi todos los aspectos, lo contrario exacto. Son servidores de Automatización basados en STA, no reentrantes, diseñados para proporcionar funcionalidad diversa pero intensiva en recursos para un solo cliente. Ofrecen poca escalabilidad como solución del lado del servidor y tienen límites fijos en elementos importantes, como la memoria, que no pueden modificarse mediante configuración. Más importante aún, utilizan recursos globales (como archivos de memoria compartida, complementos o plantillas globales y servidores de Automatización compartidos), lo que puede limitar el número de instancias que pueden ejecutarse simultáneamente y provocar condiciones de carrera si se configuran en un entorno multi-cliente. Los desarrolladores que planean ejecutar más de una instancia de cualquier aplicación de Office al mismo tiempo deben considerar el agrupamiento o la serialización del acceso a la aplicación de Office para evitar posibles bloqueos o corrupción de datos.

Los componentes de Aspose son increíblemente escalables y extremadamente rápidos. Las aplicaciones de Office no fueron diseñadas para ser utilizadas simultáneamente por cientos o miles de usuarios, pero los componentes de Aspose están diseñados precisamente para eso. Nuestros componentes son una auténtica solución .NET.

{{% alert color="info" title="Note" %}}
El rendimiento de los componentes de Aspose es impecable en un único servidor (alimentando una sola aplicación) o en un formulario web balanceado (alimentando una aplicación a nivel empresarial).
{{% /alert %}}

## **Precio**
Cuando una aplicación utiliza la Automatización de Microsoft Office, es necesario adquirir una copia de Microsoft Office para cada máquina que ejecuta la aplicación. Hay muchas ocasiones en que una aplicación necesita crear o manipular un archivo de Office, pero el proceso no requiere Microsoft Office.

{{% alert color="info" title="Note" %}}
Aspose ofrece una licencia de redistribución muy [rentable](https://purchase.aspose.com/) y libre de royalties que permite desplegar a un número ilimitado de usuarios sin preocupaciones de licenciamiento.
{{% /alert %}}

Al crear aplicaciones web, es importante recordar que los componentes de Automatización de Microsoft Office no están ni tarifados ni licenciados para soluciones del lado del servidor. Por lo tanto, no existe una solución de licenciamiento adecuada para el despliegue de aplicaciones web que utilicen componentes de Microsoft Office. Aspose, por su parte, ofrece una solución muy [rentable](https://purchase.aspose.com/) también para aplicaciones basadas en servidor.

## **Características**
Los componentes de Aspose proporcionan todo lo necesario para gestionar archivos de Office y mucho más. Los diseñamos basándonos en nuestra filosofía de ayudar a los desarrolladores a conseguir los mejores resultados posibles con el menor esfuerzo.

{{% alert color="info" title="Note" %}}
A diferencia de la Automatización de Office, los componentes de Aspose ofrecen muchas funciones potentes y que ahorran tiempo.
{{% /alert %}}

Por ejemplo, [Aspose.Cells](https://products.aspose.com/cells/net/) brinda a los desarrolladores la capacidad de importar datos desde una **DataTable** o **DataView** directamente a un archivo Excel. [Aspose.Words](https://products.aspose.com/words/net/) ofrece una característica similar que permite a los desarrolladores rellenar un documento Word (es decir, combinación de correspondencia) directamente a partir de cualquier objeto de datos .NET. [Cada componente](https://products.aspose.com/total/net/) de la familia Aspose ofrece su propio conjunto de características únicas y potentes.

La mejor parte de adquirir un componente de Aspose es obtener acceso a nuestros equipos de desarrollo. Por ejemplo, si utiliza objetos de Automatización de Office y necesita ciertas funciones, las posibilidades de que esas funciones se añadan son muy, muy bajas. Sin embargo, las cosas son diferentes con los componentes de Aspose.

{{% alert color="info" title="Note" %}}
Nuestros equipos de desarrollo entienden que si existe una característica que su empresa necesita, es muy probable que otras empresas también la requieran. Aunque sabemos que no podemos implementar cada característica solicitada, nos esforzamos por añadir la mayor cantidad posible de funcionalidades basándonos en los comentarios de nuestros clientes.
{{% /alert %}}

Nuestros equipos están siempre abiertos y son flexibles al ofrecer asistencia, y esta es la razón por la que los componentes de Aspose han llegado a ser tan potentes como son hoy.

## **Conclusión**
{{% alert color="info" title="Note" %}}
Aunque este artículo cubrió algunos de los puntos clave que explican por qué los componentes de Aspose son una mejor elección que la Automatización de Office, debe comprender que existen muchos, muchos más beneficios. Solo hemos repasado algunas de las principales ventajas.

Además, todos los productos y componentes de Aspose ofrecen una [Versión de Evaluación](https://releases.aspose.com/slides/net/) sin riesgos y sin compromiso. Le animamos a aprovechar la evaluación para ver lo que Aspose puede hacer por sus aplicaciones o su negocio.
{{% /alert %}}