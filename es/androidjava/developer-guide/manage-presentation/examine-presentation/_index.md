---
title: Recuperar y actualizar información de la presentación en Android
linktitle: Información de la presentación
type: docs
weight: 30
url: /es/androidjava/examine-presentation/
keywords:
- formato de presentación
- propiedades de la presentación
- propiedades del documento
- obtener propiedades
- leer propiedades
- cambiar propiedades
- modificar propiedades
- actualizar propiedades
- examinar PPTX
- examinar PPT
- examinar ODP
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Explore diapositivas, estructura y metadatos en presentaciones de PowerPoint y OpenDocument usando Java para obtener información más rápida y auditorías de contenido más inteligentes."
---
## **Visión general**

Este artículo muestra cómo inspeccionar la información de una presentación en Aspose.Slides. Explica cómo determinar el formato actual de una presentación sin cargar el archivo completo, leer sus propiedades de documento y actualizar esas propiedades cuando sea necesario.

Los ejemplos se basan en las API [PresentationInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationinfo/) y [DocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/documentproperties/) y demuestran operaciones típicas para trabajar con los metadatos de una presentación.

## **Comprobar el formato de una presentación**

Antes de trabajar con una presentación, puede que desee averiguar en qué formato (PPT, PPTX, ODP y otros) se encuentra la presentación en ese momento.

Puede comprobar el formato de una presentación sin cargar la presentación. Vea este código Java:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Obtener propiedades de la presentación**

Este código Java le muestra cómo obtener las propiedades de una presentación (información sobre la presentación):

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

Puede que desee consultar las [propiedades bajo la clase DocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Actualizar propiedades de la presentación**

Aspose.Slides proporciona el método [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) que permite realizar cambios en las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades del documento mostradas a continuación.

![Propiedades originales del documento de la presentación PowerPoint](input_properties.png)

Este ejemplo de código le muestra cómo editar algunas propiedades de la presentación:

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Los resultados de cambiar las propiedades del documento se muestran a continuación.

![Propiedades modificadas del documento de la presentación PowerPoint](output_properties.png)

## **Enlaces útiles**

Para obtener más información sobre una presentación y sus atributos de seguridad, puede que le resulten útiles los siguientes enlaces:

- [Presentaciones protegidas con contraseña](/slides/es/androidjava/password-protected-presentation/)
- [Presentaciones protegidas contra escritura](/slides/es/androidjava/write-protected-presentation/)

## **FAQ**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Busque la información de [fuentes incrustadas](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) a nivel de presentación y compárela con el conjunto de [fuentes realmente utilizadas en el contenido](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsmanager/#getFonts--) para identificar qué fuentes son críticas para la renderización.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Recorra la [colección de diapositivas](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slidecollection/) e inspeccione la [bandera de visibilidad](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slide/#getHidden--) de cada diapositiva.

**¿Puedo detectar si se usa un tamaño y orientación de diapositiva personalizados, y si difieren de los valores predeterminados?**

Sí. Compare el [tamaño de diapositiva](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getSlideSize--) y la orientación actuales con los valores predeterminados; esto ayuda a anticipar el comportamiento al imprimir y exportar.

**¿Existe una forma rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Recorra todos los [gráficos](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/chart/), verifique su [fuente de datos](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) y determine si los datos son internos o basados en enlaces, incluyendo cualquier enlace roto.

**¿Cómo puedo evaluar las diapositivas “pesadas” que pueden ralentizar la renderización o la exportación a PDF?**

Para cada diapositiva, contabilice el número de objetos y busque imágenes grandes, transparencias, sombras, animaciones y contenido multimedia; asigne una puntuación de complejidad aproximada para identificar posibles puntos críticos de rendimiento.