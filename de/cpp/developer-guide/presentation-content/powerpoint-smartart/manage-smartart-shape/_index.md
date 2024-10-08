---
title: SmartArt-Form verwalten
type: docs
weight: 20
url: /de/cpp/manage-smartart-shape/
---


## **SmartArt-Form erstellen**
Aspose.Slides für C++ ermöglicht es nun, benutzerdefinierte SmartArt-Formen von Grund auf in ihren Folien hinzuzufügen. Aspose.Slides für C++ bietet die einfachste API, um SmartArt-Formen auf die einfachste Weise zu erstellen. Um eine SmartArt-Form in einer Folie zu erstellen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine SmartArt-Form hinzu, indem Sie den Layouttyp festlegen.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}


## **SmartArt-Form in der Folie zugreifen**
Der folgende Code wird verwendet, um auf die in der Präsentationsfolie hinzugefügten SmartArt-Formen zuzugreifen. Im Beispielcode werden wir jede Form in der Folie durchlaufen und prüfen, ob es sich um eine SmartArt-Form handelt. Wenn die Form vom Typ SmartArt ist, werden wir sie in eine SmartArt-Instanz umwandeln.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **Auf SmartArt-Form mit bestimmtem Layouttyp zugreifen**
Der folgende Beispielcode hilft, auf die SmartArt-Form mit einem bestimmten Layouttyp zuzugreifen. Bitte beachten Sie, dass Sie den Layouttyp der SmartArt nicht ändern können, da er schreibgeschützt ist und nur festgelegt wird, wenn die SmartArt-Form hinzugefügt wird.

- Erstellen Sie eine Instanz der `Presentation` Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Erhalten Sie die Referenz der ersten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form in der ersten Folie.
- Überprüfen Sie, ob die Form vom Typ SmartArt ist, und wandeln Sie die ausgewählte Form in SmartArt um, wenn sie SmartArt ist.
- Überprüfen Sie die SmartArt-Form mit einem bestimmten Layouttyp und führen Sie aus, was danach erforderlich ist.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}


## **SmartArt-Formstil ändern**
Der folgende Beispielcode hilft, auf die SmartArt-Form mit einem bestimmten Layouttyp zuzugreifen.

- Erstellen Sie eine Instanz der `Presentation` Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Erhalten Sie die Referenz der ersten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form in der ersten Folie.
- Überprüfen Sie, ob die Form vom Typ SmartArt ist, und wandeln Sie die ausgewählte Form in SmartArt um, wenn sie SmartArt ist.
- Finden Sie die SmartArt-Form mit einem bestimmten Stil.
- Setzen Sie den neuen Stil für die SmartArt-Form.
- Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}


## **SmartArt-Formfarbstil ändern**
In diesem Beispiel lernen wir, den Farbstil für eine beliebige SmartArt-Form zu ändern. Im folgenden Beispielcode wird auf die SmartArt-Form mit einem bestimmten Farbstil zugegriffen und ihr Stil geändert.

- Erstellen Sie eine Instanz der `Presentation` Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Erhalten Sie die Referenz der ersten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form in der ersten Folie.
- Überprüfen Sie, ob die Form vom Typ SmartArt ist, und wandeln Sie die ausgewählte Form in SmartArt um, wenn sie SmartArt ist.
- Finden Sie die SmartArt-Form mit einem bestimmten Farbstil.
- Setzen Sie den neuen Farbstil für die SmartArt-Form.
- Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}