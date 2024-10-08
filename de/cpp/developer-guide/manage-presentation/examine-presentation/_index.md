---
title: Präsentation überprüfen - C++ PowerPoint API
linktitle: Präsentation überprüfen
type: docs
weight: 30
url: /de/cpp/examine-presentation/
keywords:
- PowerPoint
- präsentation
- präsentationsformat
- präsentationseigenschaften
- dokumenteigenschaften
- eigenschaften abrufen
- eigenschaften lesen
- eigenschaften ändern
- eigenschaften modifizieren
- PPTX
- PPT
- C++
description: "Lesen und Modifizieren von PowerPoint-Präsentationseigenschaften in C++"
---

Aspose.Slides für C++ ermöglicht es Ihnen, eine Präsentation zu überprüfen, um ihre Eigenschaften herauszufinden und ihr Verhalten zu verstehen.

{{% alert title="Info" color="info" %}}

Die [PresentationInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation_info) und [DocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.document_properties/) Klassen enthalten die Eigenschaften und Methoden, die hier in den Operationen verwendet werden.

{{% /alert %}} 

## **Überprüfen eines Präsentationsformats**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP und andere) sich die Präsentation im Moment befindet.

Sie können das Format einer Präsentation überprüfen, ohne die Präsentation zu laden. Sehen Sie sich diesen C++-Code an:

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

## **Präsentationseigenschaften abrufen**

Dieser C++-Code zeigt Ihnen, wie Sie die Präsentationseigenschaften (Informationen über die Präsentation) abrufen können:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ..
```

## **Präsentationseigenschaften aktualisieren**

Aspose.Slides bietet die [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) Methode, die es Ihnen ermöglicht, Änderungen an den Präsentationseigenschaften vorzunehmen.

Angenommen, wir haben eine PowerPoint-Präsentation mit den unten dargestellten Dokumenteigenschaften.

![Ursprüngliche Dokumenteigenschaften der PowerPoint-Präsentation](input_properties.png)

Dieses Codebeispiel zeigt Ihnen, wie man einige Präsentationseigenschaften bearbeitet:

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"Mein Titel");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Die Ergebnisse der Änderung der Dokumenteigenschaften sind unten dargestellt.

![Geänderte Dokumenteigenschaften der PowerPoint-Präsentation](output_properties.png)

## **Nützliche Links**

Um weitere Informationen über eine Präsentation und ihre Sicherheitsattribute zu erhalten, finden Sie diese Links nützlich:

- [Überprüfen, ob eine Präsentation verschlüsselt ist](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Überprüfen, ob eine Präsentation schreibgeschützt ist (nur lesen)](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Überprüfen, ob eine Präsentation vor dem Laden passwortgeschützt ist](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bestätigen des Passworts, das zum Schutz einer Präsentation verwendet wurde](https://docs.aspose.com/slides/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).