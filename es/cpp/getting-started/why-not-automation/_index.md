```markdown
l---
title: Por qué No Automatización
type: docs
weight: 50
url: /es/cpp/why-not-automation/
---

## **Preguntas Importantes**
- ¿Por qué los componentes de Aspose son una opción mucho mejor que la Automatización de Microsoft Office?

Hay dos preguntas que escuchamos con más frecuencia aquí en Aspose:

- ¿Sus productos requieren que Microsoft Office esté instalado para poder ejecutarse?

La respuesta corta y simple es **NO**. Aspose y los componentes de Aspose son totalmente independientes y no están afiliados, ni autorizados, patrocinados o aprobados de ninguna otra manera por Microsoft Corporation.

- ¿Por qué deberíamos usar productos de Aspose en lugar de utilizar la Automatización de Microsoft Office?

La respuesta más corta que podríamos dar es que hay muchas razones, siendo la más importante que *Microsoft mismo desaconseja firmemente la Automatización de Office desde soluciones de software: [Artículo de Microsoft](https://docs.microsoft.com/en-us/previous-versions/office/developer/cc507217(v=office.12))*

## **Descripción General**
Como se mencionó anteriormente, hay varias razones por las cuales los componentes de Aspose son una mejor alternativa a la automatización. Algunas de las razones clave son:

- Seguridad
- Estabilidad
- Escalabilidad/Velocidad
- Precio
- Características

A continuación se proporciona una mejor elaboración sobre cada uno de los puntos clave. También asegúrese de visitar la sección **Información Adicional** que proporciona enlaces a evaluaciones independientes de usuarios.

## **Seguridad**
Lo siguiente es una cita directa del artículo de Microsoft mencionado anteriormente: 
*"Las Aplicaciones de Office nunca fueron diseñadas para usarse del lado del servidor, y por lo tanto no tienen en cuenta los problemas de seguridad que enfrentan los componentes distribuidos. Office no autentica las solicitudes entrantes y no te protege de ejecutar macros inadvertidamente, o de iniciar otro servidor que podría ejecutar macros, desde tu código del lado del servidor. ¡No abras archivos que se suban al servidor desde una Web anónima! Basado en la configuración de seguridad que se estableció por última vez, el servidor puede ejecutar macros bajo un contexto de Administrador o Sistema con privilegios completos y comprometer tu red. Además, Office usa muchos componentes del lado del cliente (como Simple MAPI, WinInet, MSDAIPP) que pueden almacenar en caché la información de autenticación del cliente para acelerar el procesamiento. Si Office está siendo automatizado del lado del servidor, una instancia puede atender a más de un cliente, y dado que la información de autenticación se ha almacenado en caché para esa sesión, es posible que un cliente pueda usar las credenciales en caché de otro cliente, y así obtener permisos de acceso no concedidos al suplantar a otros usuarios."*

Los productos de Aspose son muy seguros. Por lo tanto, los componentes de Aspose no representan un riesgo potencial para los recursos vitales del sistema. Además, cuando un documento es abierto por un componente de Aspose, las macros no se ejecutan automáticamente. Los componentes de Aspose fueron construidos con el objetivo de permitir a los desarrolladores crear, manipular y guardar archivos de Office. Ninguno de los riesgos asociados con el paquete de Microsoft Office son inherentes a los componentes de Aspose.

## **Estabilidad**
Lo siguiente es una cita directa del artículo de Microsoft mencionado anteriormente: 
*"Office 2000, Office XP y Office 2003 utilizan la tecnología de Microsoft Windows Installer (MSI) para facilitar la instalación y la auto-reparación para el usuario final. MSI introduce el concepto de "instalar en el primer uso", que permite que las características se instalen o configuren dinámicamente en tiempo de ejecución (para el sistema, o más a menudo para un usuario particular). En un entorno del lado del servidor, esto tanto ralentiza el rendimiento como aumenta la probabilidad de que aparezca un cuadro de diálogo que pida al usuario que apruebe la instalación o proporcione un disco de instalación apropiado. Aunque está diseñado para aumentar la resiliencia de Office como un producto para el usuario final, la implementación de las capacidades de MSI de Office es contraproducente en un entorno del lado del servidor. Además, la estabilidad de Office en general no se puede asegurar cuando se ejecuta del lado del servidor, ya que no ha sido diseñado ni probado para este tipo de uso. Usar Office como un componente de servicio en un servidor de red puede reducir la estabilidad de esa máquina y, como consecuencia, la de tu red en su conjunto. Si planeas automatizar Office del lado del servidor, intenta aislar el programa en una computadora dedicada que no pueda afectar funciones críticas, y que pueda reiniciarse según sea necesario."*

Dado que los componentes de Aspose están empaquetados en una sola DLL, nunca habrá necesidad de instalar partes o piezas adicionales para que funcionen. Los componentes de Aspose son utilizados únicamente por aplicaciones C++ y no hay ninguna parte del código del componente diseñada para esperar una respuesta humana. Los componentes de Aspose han sido rigurosamente probados y son extremadamente estables. Los componentes de Aspose son utilizados por [Empresas](https://about.aspose.com/customers) como: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** y muchas más.

## **Escalabilidad/Velocidad**
Lo siguiente es una cita directa del artículo de Microsoft mencionado anteriormente: 

*"Los componentes del lado del servidor necesitan ser componentes COM altamente reentrantes y multi-hilo con un mínimo de sobrecarga y alta capacidad de procesamiento para múltiples clientes. Las Aplicaciones de Office son, en casi todos los aspectos, exactamente lo opuesto. Son servidores de Automatización no reentrantes, basados en STA, que están diseñados para proporcionar funcionalidad diversa pero intensiva en recursos para un solo cliente. Ofrecen poca escalabilidad como solución del lado del servidor y tienen límites fijos en elementos importantes, como la memoria, que no pueden cambiarse a través de la configuración. Más importante aún, utilizan recursos globales (como archivos de memoria mapeada, complementos o plantillas globales, y servidores de Automatización compartidos), lo cual puede limitar el número de instancias que pueden ejecutarse concurrentemente y llevar a condiciones de carrera si están configurados en un entorno de múltiples clientes. Los desarrolladores que planean ejecutar más de una instancia de cualquier Aplicación de Office al mismo tiempo deben considerar el uso de Pooling o Serializing Access para evitar posibles interbloqueos o corrupción de datos."*

Los componentes de Aspose son altamente escalables y extremadamente rápidos. Las aplicaciones de Office no fueron diseñadas para ser utilizadas simultáneamente por cientos o miles de usuarios. Sin embargo, los componentes de Aspose están diseñados justamente para eso. Nuestros componentes son una verdadera solución C++ y funcionan a la perfección ya sea en un solo servidor, alimentando una sola aplicación o en un Formulario Web balanceado que potencia una aplicación en toda la empresa.

## **Precio**
Cuando una aplicación utiliza la Automatización de Microsoft Office, se debe comprar una copia de Microsoft Office para cada máquina que ejecute la aplicación. Hay muchas ocasiones en que una aplicación puede necesitar crear o manipular un archivo de Office pero no requiere que el usuario tenga Microsoft Office. Aspose ofrece una licencia de redistribución muy [Rentable](https://purchase.aspose.com/) y libre de regalías que permitirá el despliegue a un número ilimitado de usuarios sin preocupaciones de licencia. Al crear aplicaciones basadas en la web, es importante saber que los componentes de Automatización de Microsoft Office no están fijados ni licenciados para soluciones del lado del servidor; por lo tanto, no hay buena solución de licencia para el despliegue de aplicaciones web que utilicen los componentes de Microsoft Office. Aspose también ofrece una solución muy [Rentable](https://purchase.aspose.com/) para aplicaciones basadas en servidor.

## **Características**
Los componentes de Aspose proporcionan todo lo necesario para gestionar archivos de Office y mucho más. Están diseñados con la filosofía de permitir a los desarrolladores lograr los mejores resultados con la menor cantidad de trabajo. A diferencia de la Automatización de Office, los componentes de Aspose ofrecen muchas funciones poderosas y que ahorran tiempo. Por ejemplo, [Aspose.Cells](https://products.aspose.com/cells/cpp/) ofrece a los desarrolladores la capacidad de importar datos desde un **DataTable** o **DataView** directamente en un archivo de Excel. [Aspose.Words](https://products.aspose.com/words/net/) ofrece una característica similar que permite a los desarrolladores llenar un documento de Word (que es un Mail Merge) directamente desde cualquier objeto de datos C++. [Cada Componente](https://products.aspose.com/total/cpp/) en la familia Aspose ofrece su propio conjunto de características únicas y poderosas. La mejor parte de comprar un componente de Aspose es tener acceso a nuestros equipos de desarrollo. Nuestros equipos de desarrollo se dan cuenta de que si hay una característica que tu empresa necesita, lo más probable es que otras empresas también la necesiten. Aunque no se puede añadir cada solicitud de función, nuestros equipos intentan ser muy abiertos y flexibles al proporcionar asistencia. Esa mentalidad es lo que ha ayudado a que los componentes de Aspose sean tan potentes como son. Si hay características adicionales que necesitas de los objetos de Automatización de Office, tus posibilidades de que se añadan son muy, muy bajas.

## **Conclusión**
{{% alert color="primary" %}} 

Si bien este artículo ha cubierto muchos de los puntos clave sobre por qué los componentes de Aspose son una mejor opción que la Automatización de Office, hay muchos, muchos más. Este artículo aborda principalmente solo los puntos más clave. Todos los diferentes componentes de Aspose ofrecen una versión de [Evaluación](https://downloads.aspose.com/slides/cpp) sin riesgos y sin obligación. Te animamos a aprovechar esa [Evaluación](https://downloads.aspose.com/slides/cpp) para ver mejor lo que Aspose puede hacer por tus aplicaciones.
```