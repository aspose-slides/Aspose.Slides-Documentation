---
title: Präsentation überprüfen
type: docs
weight: 30
url: /python-net/examine-presentation/
keywords:
- PowerPoint
- Präsentation
- Präsentationsformat
- Präsentationseigenschaften
- Dokumenteigenschaften
- Eigenschaften abrufen
- Eigenschaften lesen
- Eigenschaften ändern
- Eigenschaften modifizieren
- PPTX
- PPT
- Python
description: "Lesen und Ändern von PowerPoint-Präsentationseigenschaften in Python"
---

Aspose.Slides für Python über .NET ermöglicht es Ihnen, eine Präsentation zu überprüfen, um ihre Eigenschaften herauszufinden und ihr Verhalten zu verstehen.

{{% alert title="Info" color="info" %}} 

Die [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) und [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) Klassen enthalten die Eigenschaften und Methoden, die hier in den Operationen verwendet werden.

{{% /alert %}} 

## **Präsentationsformat überprüfen**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP und andere) sich die Präsentation im Moment befindet.

Sie können das Format einer Präsentation überprüfen, ohne die Präsentation zu laden. Sehen Sie sich diesen Python-Code an:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Präsentationseigenschaften abrufen**

Dieser Python-Code zeigt Ihnen, wie Sie die Präsentationseigenschaften (Informationen über die Präsentation) abrufen können:

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Sie möchten möglicherweise die [Eigenschaften unter der DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties) Klasse sehen.

## **Präsentationseigenschaften aktualisieren**

Aspose.Slides bietet die [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) Methode, die es Ihnen ermöglicht, Änderungen an den Präsentationseigenschaften vorzunehmen.

Angenommen, wir haben eine PowerPoint-Präsentation mit den folgenden dokumenteigenschaften.

![Originale Dokumenteigenschaften der PowerPoint-Präsentation](input_properties.png)

Dieses Codebeispiel zeigt Ihnen, wie Sie einige Präsentationseigenschaften bearbeiten:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "Mein Titel"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Die Ergebnisse der Änderung der Dokumenteigenschaften sind unten gezeigt.

![Geänderte Dokumenteigenschaften der PowerPoint-Präsentation](output_properties.png)

## **Nützliche Links**

Um mehr Informationen über eine Präsentation und ihre Sicherheitsattribute zu erhalten, könnten Sie diese Links nützlich finden:

- [Überprüfen, ob eine Präsentation verschlüsselt ist](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Überprüfen, ob eine Präsentation schreibgeschützt (nur lesen) ist](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Überprüfen, ob eine Präsentation vor dem Laden passwortgeschützt ist](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bestätigen des Passworts, das zum Schutz einer Präsentation verwendet wurde](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).