---
title: Examinar Presentación - API de PowerPoint C++
linktitle: Examinar Presentación
type: docs
weight: 30
url: /cpp/examine-presentation/
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
- C++
description: "Leer y modificar propiedades de presentaciones de PowerPoint en C++"
---

Aspose.Slides para C++ permite examinar una presentación para averiguar sus propiedades y entender su comportamiento. 

{{% alert title="Info" color="info" %}}

Las clases [PresentationInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation_info) y [DocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.document_properties/) contienen las propiedades y métodos utilizados en las operaciones aquí.

{{% /alert %}} 

## **Comprobar el Formato de una Presentación**

Antes de trabajar en una presentación, puede que desee averiguar en qué formato (PPT, PPTX, ODP, y otros) se encuentra la presentación en este momento.

Puede comprobar el formato de una presentación sin cargarla. Vea este código en C++:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Obtener Propiedades de la Presentación**

Este código en C++ le muestra cómo obtener las propiedades de la presentación (información sobre la presentación):

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **Actualizar Propiedades de la Presentación**

Aspose.Slides proporciona el método [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) que permite realizar cambios en las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades del documento que se muestran a continuación.

![Propiedades originales del documento de la presentación de PowerPoint](input_properties.png)

Este ejemplo de código le muestra cómo editar algunas propiedades de la presentación:

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"Mi título");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Los resultados de cambiar las propiedades del documento se muestran a continuación.

![Propiedades cambiadas del documento de la presentación de PowerPoint](output_properties.png)

## **Enlaces Útiles**

Para obtener más información sobre una presentación y sus atributos de seguridad, puede encontrar útiles estos enlaces:

- [Comprobar si una Presentación está Encriptada](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Comprobar si una Presentación está Protegida contra Escritura (solo lectura)](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Comprobar si una Presentación está Protegida por Contraseña Antes de Cargarla](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmar la Contraseña Usada para Proteger una Presentación](https://docs.aspose.com/slides/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).