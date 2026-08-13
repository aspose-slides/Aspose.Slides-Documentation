---
title: Por qué no automatizar
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
## **Introducción**

Hay varias razones por las que los componentes de Aspose son una alternativa mejor que la automatización. Algunas de las razones clave son:

- Seguridad
- Estabilidad
- Escalabilidad/Rendimiento
- Precio
- Características

A continuación se muestra una explicación más detallada de cada punto clave.

## **Preguntas importantes**

Hay dos preguntas que solemos escuchar en Aspose:

- ¿Requieren sus productos que Microsoft Office esté instalado para poder ejecutarse?

La respuesta corta y simple es **NO**.

Los componentes de Aspose son completamente independientes y no están afiliados, autorizados, patrocinados ni aprobados de ninguna manera por Microsoft Corporation.

- ¿Por qué deberíamos usar los productos Aspose en lugar de la automatización de Microsoft Office?

En primer lugar, existen muchos [beneficios que obtiene al usar Aspose.Slides](/slides/es/net/product-overview/).

En segundo lugar, Microsoft mismo **desaconseja** utilizar la automatización de Office en soluciones de software.

## **Seguridad**
La siguiente es una cita directa de un artículo de Microsoft: 

> "Las aplicaciones de Office nunca fueron diseñadas para usarse del lado del servidor y, por lo tanto, no consideran los problemas de seguridad que enfrentan los componentes distribuidos. Office no autentica las solicitudes entrantes y no le protege de ejecutar macros involuntariamente, ni de iniciar otro servidor que pueda ejecutar macros desde su código del lado del servidor. ¡No abra archivos que se carguen al servidor desde la web de forma anónima! Según la configuración de seguridad establecida por última vez, el servidor puede ejecutar macros bajo un contexto de Administrador o Sistema con privilegios completos y comprometer su red. Además, Office usa muchos componentes del lado del cliente (como Simple MAPI, WinInet, MSDAIPP) que pueden almacenar en caché la información de autenticación del cliente para acelerar el procesamiento. Si Office se automatiza del lado del servidor, una instancia puede atender a más de un cliente y, como la información de autenticación se ha almacenado en caché para esa sesión, es posible que un cliente use las credenciales almacenadas de otro cliente y, de ese modo, obtenga permisos de acceso no concedidos al suplantar a otros usuarios."

Los productos Aspose son muy **secure**. Los componentes Aspose se ejecutan en el mismo contexto de usuario que todas las aplicaciones ASP.NET (bajo el usuario ASPNET). Por lo tanto, los componentes Aspose **not** suponen un riesgo de seguridad. Tampoco consumen recursos críticos del sistema. Además, cuando un componente Aspose abre un documento, las macros no se ejecutan automáticamente. Los componentes Aspose fueron creados para permitir a los desarrolladores crear, manipular y guardar archivos de Office. 

{{% alert color="info" %}} 

Ninguno de los riesgos asociados con el paquete Microsoft Office se aplica a los componentes Aspose.

{{% /alert %}} 

## **Estabilidad**
Este texto es una cita directa del artículo de Microsoft mencionado anteriormente: 

> "Office 2000, Office XP y Office 2003 utilizan la tecnología Microsoft Windows Installer (MSI) para facilitar la instalación y la autorreparación al usuario final. MSI introduce el concepto de “instalar al primer uso”, que permite que las características se instalen o configuren dinámicamente en tiempo de ejecución (para el sistema o, con mayor frecuencia, para un usuario concreto). En un entorno del lado del servidor, esto ralentiza el rendimiento y aumenta la probabilidad de que aparezca un cuadro de diálogo que pida al usuario que apruebe la instalación o proporcione un disco de instalación adecuado. Aunque está diseñado para aumentar la resiliencia de Office como producto de usuario final, la implementación de MSI por parte de Office es contraproducente en un entorno del lado del servidor. Además, no se puede garantizar la estabilidad de Office en general cuando se ejecuta del lado del servidor porque no ha sido diseñado ni probado para este tipo de uso. Usar Office como componente de servicio en un servidor de red puede reducir la estabilidad de esa máquina y, en consecuencia, de toda su red. Si planea automatizar Office del lado del servidor, intente aislar el programa en un equipo dedicado que no pueda afectar funciones críticas y que pueda reiniciarse según sea necesario."

Dado que los componentes Aspose se empaquetan en una única DLL, sus usuarios nunca necesitan instalar partes o piezas adicionales para que funcionen. Los componentes Aspose sólo son utilizados por aplicaciones .NET y no hay ninguna parte del código del componente diseñada para esperar una respuesta humana. 

{{% alert color="info" %}} 

Los componentes Aspose han sido probados exhaustivamente y se ha confirmado que son muy estables. Los componentes Aspose son utilizados por [companies](http://www.aspose.com/Corporate/Aspose/Customerlist.html) como **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, y muchas otras organizaciones líderes en varios sectores e industrias. 

{{% /alert %}} 

## **Escalabilidad/Rendimiento**
La siguiente es una cita directa de un artículo de Microsoft: 

> "Los componentes del lado del servidor deben ser componentes COM altamente reentrantes, multihilo, con un mínimo consumo y alto rendimiento para varios clientes. Las aplicaciones de Office son, en casi todos los aspectos, exactamente lo contrario. Son servidores de automatización no reentrantes, basados en STA, diseñados para proporcionar funcionalidades diversas pero intensivas en recursos para un único cliente. Ofrecen poca escalabilidad como solución del lado del servidor y tienen límites fijos en elementos importantes, como la memoria, que no pueden modificarse mediante configuración. Más importante aún, utilizan recursos globales (como archivos mapeados en memoria, complementos o plantillas globales y servidores de automatización compartidos), lo que puede limitar el número de instancias que pueden ejecutarse simultáneamente y provocar condiciones de carrera si se configuran en un entorno multi‑cliente. Los desarrolladores que planeen ejecutar más de una instancia de cualquier aplicación de Office al mismo tiempo deben considerar la agrupación o la serialización del acceso a la aplicación de Office para evitar posibles bloqueos o corrupción de datos."

Los componentes Aspose son increíblemente escalables y ultrarrápidos. Las aplicaciones de Office no fueron diseñadas para ser usadas simultáneamente por cientos o miles de usuarios, pero los componentes Aspose están diseñados precisamente para eso. Nuestros componentes son una solución .NET auténtica. 

{{% alert color="info" %}} 

El rendimiento de los componentes Aspose es impecable tanto en un solo servidor (alimentando una única aplicación) como en un web farm balanceado (alimentando una aplicación empresarial a gran escala).

{{% /alert %}} 

## **Precio**
Cuando una aplicación utiliza la automatización de Microsoft Office, hay que comprar una copia de Microsoft Office para cada máquina que ejecute la aplicación. Hay muchas instancias en las que una aplicación puede necesitar crear o manipular un archivo de Office, pero el proceso no requiere Microsoft Office. 

{{% alert color="info" %}} 

Aspose ofrece una licencia de redistribución muy [cost-effective](https://purchase.aspose.com/) y libre de royalties que permite el despliegue a un número ilimitado de usuarios sin preocuparse por licencias. 

{{% /alert %}} 

Al crear aplicaciones web, es importante recordar que los componentes de automatización de Microsoft Office no tienen un precio ni una licencia adecuada para soluciones del lado del servidor. Por lo tanto, no existe una solución de licenciamiento adecuada para el despliegue de aplicaciones web que utilicen componentes de Microsoft Office. Aspose, por su parte, ofrece una solución muy [cost-effective](https://purchase.aspose.com/) para aplicaciones basadas en servidor también.

## **Características**
Los componentes Aspose proporcionan todo lo necesario para gestionar archivos de Office y mucho más. Los diseñamos basándonos en nuestra filosofía de ayudar a los desarrolladores a lograr los mejores resultados posibles con el menor esfuerzo. 

{{% alert color="info" %}} 

A diferencia de la automatización de Office, los componentes Aspose ofrecen muchas funciones potentes y que ahorran tiempo. 

{{% /alert %}} 

Por ejemplo, [Aspose.Cells](https://products.aspose.com/cells/net/) permite a los desarrolladores importar datos desde una **DataTable** o **DataView** directamente a un archivo Excel. [Aspose.Words](https://products.aspose.com/words/net/) ofrece una funcionalidad similar que permite a los desarrolladores rellenar un documento Word (es decir, combinación de correspondencia) directamente desde cualquier objeto de datos .NET. [Every component](https://products.aspose.com/total/net/) de la familia Aspose ofrece su propio conjunto de características únicas y potentes. 

Lo mejor de adquirir un componente Aspose es el acceso a nuestros equipos de desarrollo. Por ejemplo, si usa objetos de automatización de Office y necesita ciertas funciones, las posibilidades de que esas funciones se añadan son muy, muy bajas. Sin embargo, la situación es diferente con los componentes Aspose. 

{{% alert color="info" %}} 

Nuestros equipos de desarrollo entienden que si hay una característica que su empresa necesita, es muy probable que otras compañías también la necesiten. Aunque sabemos que no podemos implementar todas las funciones solicitadas, nos esforzamos por añadir la mayor cantidad posible de características basándonos en los comentarios de nuestros clientes. 

{{% /alert %}} 

Nuestros equipos están siempre con la mente abierta y son flexibles al proporcionar asistencia, y esa es la razón por la que los componentes Aspose han llegado a ser tan potentes como son hoy. 

## **Conclusión**
{{% alert color="info" %}} 

Aunque este artículo cubre algunos de los puntos clave que explican por qué los componentes Aspose son una mejor opción que la automatización de Office, debe entender que existen muchos, muchos más beneficios. Sólo hemos repasado algunas de las principales ventajas. 

Además, todos los productos y componentes Aspose ofrecen una [Evaluation Version](https://downloads.aspose.com/slides/es/net) sin riesgo y sin compromiso. Le animamos a aprovechar la evaluación para ver qué puede hacer Aspose por sus aplicaciones o su negocio. 

{{% /alert %}}