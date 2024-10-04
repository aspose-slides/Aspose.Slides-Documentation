---
title: Por Qué No Automatización
type: docs
weight: 40
url: /es/net/why-not-automation/
---

## **Preguntas Importantes**
- ¿Por qué los componentes de Aspose son una opción mucho mejor que la Automatización de Microsoft Office?

Hay dos preguntas que a menudo escuchamos en Aspose:

- ¿Sus productos requieren que Microsoft Office esté instalado para funcionar?

La respuesta corta y simple—**NO**.

Aspose y los componentes de Aspose son totalmente independientes y no están afiliados a, ni autorizados, patrocinados, o de alguna otra manera aprobados por Microsoft Corporation.

- ¿Por qué deberíamos usar los productos de Aspose en lugar de utilizar la Automatización de Microsoft Office?

Por un lado, hay muchos [beneficios que disfrutas cuando usas Aspose.Slides](https://docs.aspose.com/slides/net/product-overview/).

Por otro lado, Microsoft mismo **desaconseja** enérgicamente el uso de la Automatización de Office en soluciones de software.

## **Resumen**
Como mencionamos anteriormente, hay varias razones por las cuales los componentes de Aspose son una mejor alternativa a la automatización. Algunas de las razones clave son:

- Seguridad
- Estabilidad
- Escalabilidad/Velocidad
- Precio
- Características

Desarrollamos las razones clave en los párrafos a continuación.
## **Seguridad**
Lo siguiente es una cita directa de un artículo de Microsoft:

> "Las aplicaciones de Office nunca fueron diseñadas para su uso en el lado del servidor, y por lo tanto no tienen en cuenta los problemas de seguridad que enfrentan los componentes distribuidos. Office no autentica las solicitudes entrantes y no te protege de ejecutar macros accidentalmente, o iniciar otro servidor que podría ejecutar macros, desde tu código del lado del servidor. ¡No abras archivos que se suben al servidor desde una Web anónima! Basado en los ajustes de seguridad que se establecieron por última vez, el servidor puede ejecutar macros bajo un contexto de Administrador o Sistema con plenos privilegios y comprometer tu red. Además, Office utiliza muchos componentes del lado del cliente (como Simple MAPI, WinInet, MSDAIPP) que pueden almacenar en caché la información de autenticación del cliente para acelerar el procesamiento. Si Office se está automatizando en el lado del servidor, una instancia puede atender a más de un cliente, y como la información de autenticación ha sido almacenada en caché para esa sesión, es posible que un cliente pueda usar las credenciales almacenadas en caché de otro cliente, y así obtener permisos de acceso no otorgados al hacerse pasar por otros usuarios."

Los productos Aspose son muy **seguros**. Los componentes de Aspose se ejecutan en el mismo contexto de usuario que todas las aplicaciones ASP.NET (bajo el usuario ASPNET). Por lo tanto, los componentes de Aspose **no** suponen un riesgo de seguridad. Tampoco consumen recursos críticos del sistema. Además, cuando un componente de Aspose abre un documento, las macros no se ejecutan automáticamente. Los componentes de Aspose fueron creados para permitir que los desarrolladores creen, manipulen y guarden archivos de Office.

{{% alert color="primary" %}} 

Ninguno de los riesgos asociados con el paquete de Microsoft Office se aplica a los componentes de Aspose.

{{% /alert %}} 

## **Estabilidad**
Este texto es una cita directa del artículo de Microsoft mencionado anteriormente:

> "Office 2000, Office XP y Office 2003 utilizan la tecnología Microsoft Windows Installer (MSI) para facilitar la instalación y la auto-reparación para un usuario final. MSI introduce el concepto de "instalación en el primer uso", que permite que las características se instalen o configuren dinámicamente en tiempo de ejecución (para el sistema, o más a menudo para un usuario particular). En un entorno del lado del servidor, esto ralentiza el rendimiento y aumenta la probabilidad de que aparezca un cuadro de diálogo que pida al usuario que apruebe la instalación o proporcione un disco de instalación adecuado. Aunque está diseñado para aumentar la resiliencia de Office como producto para el usuario final, la implementación de las capacidades de MSI de Office es contraproducente en un entorno del lado del servidor. Además, la estabilidad de Office en general no puede ser asegurada cuando se ejecuta en el lado del servidor porque no ha sido diseñada ni probada para este tipo de uso. Usar Office como un componente de servicio en un servidor de red puede reducir la estabilidad de esa máquina y, como consecuencia, de tu red en su conjunto. Si planeas automatizar Office en el lado del servidor, intenta aislar el programa en una computadora dedicada que no pueda afectar funciones críticas y que se pueda reiniciar según sea necesario."

Dado que los componentes de Aspose están empaquetados en una única DLL, sus usuarios nunca necesitan instalar partes o piezas adicionales para que funcionen. Los componentes de Aspose solo son utilizados por aplicaciones .NET y no hay parte del código del componente diseñada para esperar una respuesta humana.

{{% alert color="primary" %}} 

Los componentes de Aspose han sido minuciosamente probados y confirmados como muy estables. Los componentes de Aspose son utilizados por [empresas](http://www.aspose.com/Corporate/Aspose/Customerlist.html) como **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, y muchas otras organizaciones líderes en varias industrias y campos.

{{% /alert %}} 

## **Escalabilidad/Velocidad**
Lo siguiente es una cita directa de un artículo de Microsoft:

> "Los componentes del lado del servidor necesitan ser componentes COM altamente reentrantes, multihilo, con mínimo sobrecosto y alto rendimiento para múltiples clientes. Las aplicaciones de Office son casi en todos los aspectos lo opuesto exacto. Son servidores de Automatización basados en STA que están diseñados para proporcionar funcionalidad diversa pero intensiva en recursos para un solo cliente. Ofrecen poca escalabilidad como solución del lado del servidor y tienen límites fijos en elementos importantes, como la memoria, que no pueden ser cambiados a través de la configuración. Más importante aún, utilizan recursos globales (como archivos mapeados en memoria, complementos o plantillas globales, y servidores de automatización compartidos), lo que puede limitar el número de instancias que pueden ejecutarse simultáneamente y provocar condiciones de carrera si están configurados en un entorno de múltiples clientes. Los desarrolladores que planean ejecutar más de una instancia de cualquier aplicación de Office al mismo tiempo deben considerar el uso de agrupamiento o la serialización de acceso a la aplicación de Office para evitar posibles bloqueos o corrupción de datos."

Los componentes de Aspose son increíblemente escalables y ultrarrápidos. Las aplicaciones de Office no fueron diseñadas para ser utilizadas simultáneamente por cientos o miles de usuarios, pero los componentes de Aspose están diseñados precisamente para eso. Nuestros componentes son una verdadera solución .NET.

{{% alert color="primary" %}} 

El rendimiento de los componentes de Aspose es impecable en un solo servidor (alimentando una sola aplicación) o en un formulario web balanceado por carga (alimentando una aplicación a nivel empresarial).

{{% /alert %}} 

## **Precio**
Cuando una aplicación utiliza Automatización de Microsoft Office, se debe comprar una copia de Microsoft Office para cada máquina que ejecute la aplicación. Hay muchos casos en que una aplicación puede necesitar crear o manipular un archivo de Office, pero el proceso no requiere Microsoft Office.

{{% alert color="primary" %}} 

Aspose ofrece una licencia de redistribución muy [económica](https://purchase.aspose.com/) y libre de regalías que permite el despliegue a un número ilimitado de usuarios sin preocupaciones de licencias.

{{% /alert %}} 

Al crear aplicaciones basadas en la web, es importante recordar que los componentes de Automatización de Microsoft Office no están ni precios ni licenciados para soluciones del lado del servidor. Por lo tanto, no hay una buena solución de licencia para el despliegue de aplicaciones web que utilicen componentes de Microsoft Office. Aspose, por otro lado, proporciona una solución muy [económica](https://purchase.aspose.com/) para aplicaciones basadas en servidor también.

## **Características**
Los componentes de Aspose proporcionan todo lo necesario para gestionar archivos de Office y mucho más. Los diseñamos basándonos en nuestra filosofía de ayudar a los desarrolladores a lograr los mejores resultados posibles con el menor esfuerzo posible.

{{% alert color="primary" %}} 

A diferencia de la Automatización de Office, los componentes de Aspose ofrecen muchas funciones poderosas y que ahorran tiempo.

{{% /alert %}} 

Por ejemplo, [Aspose.Cells](https://products.aspose.com/cells/net/) le da a los desarrolladores la capacidad de importar datos de un **DataTable** o **DataView** directamente en un archivo de Excel. [Aspose.Words](https://products.aspose.com/words/net/) ofrece una función similar que permite a los desarrolladores poblar un documento de Word (es decir, Combinación de Correspondencia) directamente desde cualquier objeto de datos .NET. [Cada componente](https://products.aspose.com/total/net/) de la familia Aspose ofrece su propio conjunto de características únicas y potentes.

La mejor parte de comprar un componente de Aspose es obtener acceso a nuestros equipos de desarrollo. Por ejemplo, si utilizas objetos de Automatización de Office y necesitas ciertas características, las posibilidades de que esas características se añadan son muy, muy bajas. Sin embargo, las cosas son diferentes con los componentes de Aspose.

{{% alert color="primary" %}} 

Nuestros equipos de desarrollo entienden que si hay una característica que tu empresa necesita, hay una buena probabilidad de que otras empresas necesiten la misma característica. Aunque sabemos que no podemos implementar todas las características solicitadas, nos esforzamos por añadir tantas características como sea posible basándonos en los comentarios de nuestros clientes.

{{% /alert %}} 

Nuestros equipos están siempre abiertos y son flexibles al proporcionar asistencia—y esta es la razón por la que los componentes de Aspose han crecido para llegar a ser tan poderosos como lo son ahora.

## **Conclusión**
{{% alert color="primary" %}} 

Si bien este artículo cubrió algunos de los puntos clave por los cuales los componentes de Aspose son una mejor opción que la Automatización de Office, debes entender que hay muchos, muchos más beneficios. Solo pasamos por algunas de las principales ventajas.

Además, todos los productos y componentes de Aspose ofrecen una [Versión de Evaluación](https://downloads.aspose.com/slides/net) sin riesgo y sin compromiso. Te animamos a aprovechar la evaluación para ver lo que Aspose puede hacer por tus aplicaciones o negocio.

{{% /alert %}} 