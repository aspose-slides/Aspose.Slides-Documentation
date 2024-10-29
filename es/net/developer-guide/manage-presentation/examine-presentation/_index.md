---
title: Examinar Presentación
type: docs
weight: 30
url: /es/net/examine-presentation/
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
- C#
- Csharp
- .NET
description: "Leer y modificar propiedades de presentación de PowerPoint en C# o .NET"
---

Aspose.Slides para .NET te permite examinar una presentación para descubrir sus propiedades y comprender su comportamiento.

{{% alert title="Info" color="info" %}} 

Las clases [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) y [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) contienen las propiedades y métodos utilizados en las operaciones aquí.

{{% /alert %}} 

## **Verificar un Formato de Presentación**

Antes de trabajar en una presentación, es posible que desees averiguar en qué formato (PPT, PPTX, ODP y otros) se encuentra la presentación en ese momento.

Puedes verificar el formato de una presentación sin cargarla. Mira este código en C#:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Obtener Propiedades de Presentación**

Este código en C# te muestra cómo obtener las propiedades de la presentación (información sobre la presentación):

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```

Es posible que desees ver las [propiedades de la clase DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties).

## **Actualizar Propiedades de Presentación**

Aspose.Slides proporciona el método [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) que te permite realizar cambios en las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades del documento que se muestran a continuación.

![Propiedades del documento originales de la presentación de PowerPoint](input_properties.png)

Este ejemplo de código te muestra cómo editar algunas propiedades de la presentación:

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "Mi título";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Los resultados de cambiar las propiedades del documento se muestran a continuación.

![Propiedades del documento cambiadas de la presentación de PowerPoint](output_properties.png)

## **Enlaces Útiles**

Para obtener más información sobre una presentación y sus atributos de seguridad, puede que encuentres útiles estos enlaces:

- [Comprobar si una Presentación está Encriptada](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Comprobar si una Presentación está Protegida contra Escritura (solo lectura)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Comprobar si una Presentación está Protegida por Contraseña Antes de Cargarla](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmar la Contraseña Usada para Proteger una Presentación](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).