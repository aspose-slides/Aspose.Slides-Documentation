---
title: Examinar Presentación
type: docs
weight: 30
url: /java/examine-presentation/
keywords:
- PowerPoint
- presentación
- formato de presentación
- propiedades de presentación
- propiedades del documento
- obtener propiedades
- leer propiedades
- cambiar propiedades
- modificar propiedades
- PPTX
- PPT
- Java
description: "Leer y modificar propiedades de presentaciones de PowerPoint en Java"
---

Aspose.Slides para Java te permite examinar una presentación para descubrir sus propiedades y entender su comportamiento.

{{% alert title="Información" color="info" %}} 

Las clases [PresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/PresentationInfo) y [DocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/) contienen las propiedades y métodos utilizados en las operaciones aquí.

{{% /alert %}} 

## **Verificar un Formato de Presentación**

Antes de trabajar en una presentación, es posible que desees averiguar en qué formato (PPT, PPTX, ODP, entre otros) se encuentra la presentación en este momento.

Puedes comprobar el formato de una presentación sin cargar la presentación. Ve este código Java:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Obtener Propiedades de la Presentación**

Este código Java te muestra cómo obtener propiedades de la presentación (información sobre la presentación):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

Es posible que desees ver las [propiedades bajo la clase DocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Actualizar Propiedades de la Presentación**

Aspose.Slides proporciona el método [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) que te permite realizar cambios en las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades del documento que se muestran a continuación.

![Propiedades del documento originales de la presentación de PowerPoint](input_properties.png)

Este ejemplo de código te muestra cómo editar algunas propiedades de la presentación:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("Mi título");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Los resultados de cambiar las propiedades del documento se muestran a continuación.

![Propiedades del documento cambiadas de la presentación de PowerPoint](output_properties.png)

## **Enlaces Útiles**

Para obtener más información sobre una presentación y sus atributos de seguridad, es posible que encuentres útiles estos enlaces:

- [Verificar si una Presentación está Encriptada](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Verificar si una Presentación está Protegida contra Escritura (solo lectura)](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Verificar si una Presentación está Protegida por Contraseña Antes de Cargarla](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmar la Contraseña Usada para Proteger una Presentación](https://docs.aspose.com/slides/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).