---
title: Verwalten von Aufzählungs- und Nummerierungslisten in Präsentationen mit Python via Java
linktitle: Listen verwalten
type: docs
weight: 60
url: /de/python-java/manage-lists/
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- Nummerierte Liste
- Symbol‑Aufzählungszeichen
- Bild‑Aufzählungszeichen
- Benutzerdefiniertes Aufzählungszeichen
- Mehrstufige Liste
- Aufzählungszeichen erstellen
- Aufzählungszeichen hinzufügen
- Liste hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aufzählungslisten, Bild‑Aufzählungszeichen, mehrstufige Listen und nummerierte Listen in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Python via Java erstellen und formatieren."
---
## **Überblick**

Aspose.Slides für Python via Java ermöglicht das Erstellen und Formatieren von Aufzählungs- und Nummerierungslisten in PowerPoint‑ und OpenDocument‑Präsentationen. Ein Listeneintrag ist ein Absatz, dessen Aufzählungs‑Einstellungen über das Absatzformat gesteuert werden.

Verwenden Sie die [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraph/#getParagraphFormat)-Methode, um die Absatzeinstellungen für Listen zuzugreifen. Der Haupteinstiegspunkt ist [ParagraphFormat.getBullet](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#getBullet), die ein [BulletFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/bulletformat/)‑Objekt zurückgibt. Mit diesem Objekt können Sie den Aufzählungstyp, das Symbol, das Bild, die Farbe, die Größe, den Nummerierungsstil und die Startnummer festlegen.

Dieser Artikel zeigt, wie man:

- eine Aufzählungsliste mit einem benutzerdefinierten Symbol erstellen
- eine Bildaufzählung erstellen
- eine mehrstufige Liste erstellen, indem die Absatz‑tiefe festgelegt wird
- eine nummerierte Liste erstellen
- Listformatierungen in einer vorhandenen Präsentation prüfen und ändern

## **Aufzählungsliste erstellen**

Um eine Aufzählungsliste zu erstellen, fügen Sie [Paragraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraph/)-Objekte zu einem [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) hinzu und setzen [BulletFormat.setType](https://reference.aspose.com/slides/de/python-java/aspose.slides/bulletformat/#setType) auf [BulletType.Symbol](https://reference.aspose.com/slides/de/python-java/aspose.slides/bullettype/#Symbol). Anschließend können Sie [BulletFormat.setChar](https://reference.aspose.com/slides/de/python-java/aspose.slides/bulletformat/#setChar), [BulletFormat.getColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/bulletformat/#getColor) und [BulletFormat.setHeight](https://reference.aspose.com/slides/de/python-java/aspose.slides/bulletformat/#setHeight) verwenden, um das Aussehen der Aufzählungszeichen zu steuern.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NullableBool, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    bullet_color = Color(205, 92, 92)

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar('*')
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    first_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('*')
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    second_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die Symbolaufzählungen](symbol_bullets.png)

## **Nummerierte Liste erstellen**

Verwenden Sie nummerierte Listen, wenn die Reihenfolge der Elemente wichtig ist. Setzen Sie [BulletFormat.setType](https://reference.aspose.com/slides/de/python-java/aspose.slides/bulletformat/#setType) auf [BulletType.Numbered](https://reference.aspose.com/slides/de/python-java/aspose.slides/bullettype/#Numbered). Sie können außerdem ein Nummerierungsformat mit [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/de/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) auswählen oder [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/de/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) verwenden, wenn die Liste mit einem anderen Wert als 1 beginnen soll.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.setText("Apple")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.setText("Orange")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.setText("Banana")
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die nummerierten Aufzählungszeichen](numbered_bullets.png)

## **Bildaufzählung erstellen**

Aspose.Slides ermöglicht es, ein reguläres Aufzählungszeichen durch ein Bild zu ersetzen. Bildaufzählungen funktionieren am besten mit einfachen Bildern, die auch in kleiner Größe lesbar bleiben, wie z. B. Icons oder kleine transparente PNG‑Dateien.

{{% alert color="info" title="Note" %}}
Wenn Sie ein reguläres Aufzählungszeichen durch ein Bild ersetzen möchten, wählen Sie eine einfache Grafik mit transparentem Hintergrund. Solche Bilder eignen sich gut als benutzerdefinierte Aufzählungszeichen.
{{% /alert %}}

Um eine Bildaufzählung zu erstellen, fügen Sie ein Bild zu [Presentation.getImages](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getImages) hinzu und weisen das zurückgegebene Bildobjekt [BulletFormat.getPicture](https://reference.aspose.com/slides/de/python-java/aspose.slides/bulletformat/#getPicture) zu. Setzen Sie [BulletFormat.setType](https://reference.aspose.com/slides/de/python-java/aspose.slides/bulletformat/#setType) auf [BulletType.Picture](https://reference.aspose.com/slides/de/python-java/aspose.slides/bullettype/#Picture), bevor Sie das Bild zuweisen.

Angenommen, wir haben ein Bild mit dem Namen "image.png":

![Ein Bild für die Aufzählungszeichen](picture_for_bullets.png)

Der folgende Python‑Code zeigt, wie man Bildaufzählungen auf einer Folie erstellt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    image = Images.fromFile("image.png")
    try:
        bullet_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    first_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    second_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die Bildaufzählungen](picture_bullets.png)

## **Mehrstufige Liste erstellen**

Verwenden Sie [ParagraphFormat.setDepth](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#setDepth), um Listeneinträge auf verschiedenen Ebenen zu platzieren. Ebene 0 ist die oberste Ebene, Ebene 1 liegt darunter usw.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().setDepth(0)
    first_paragraph.setText("My text - Depth 0")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().setDepth(1)
    second_paragraph.setText("My text - Depth 1")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().setDepth(2)
    third_paragraph.setText("My text - Depth 2")
    text_frame.getParagraphs().add(third_paragraph)

    fourth_paragraph = Paragraph()
    fourth_paragraph.getParagraphFormat().setDepth(3)
    fourth_paragraph.setText("My text - Depth 3")
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die mehrstufige Liste](multilevel_list.png)

## **Vorhandene Liste ändern**

Um die Listformatierung in einer vorhandenen Präsentation zu ändern, greifen Sie auf den Zielabsatz zu und aktualisieren dessen [ParagraphFormat.getBullet](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#getBullet)-Einstellungen. Die gleichen Eigenschaften, die zum Erstellen von Listen verwendet werden, können verwendet werden, um Listen, die aus einer PPT-, PPTX- oder ODP‑Datei geladen wurden, zu prüfen oder zu ändern.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NumberedBulletStyle, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(1)
    paragraph.getParagraphFormat().setMarginLeft(30)
    paragraph.getParagraphFormat().setIndent(-20)

    presentation.save("updated_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Können Aufzählungs- und Nummerierungslisten in PDF oder Bilder exportiert werden?**

Ja. Aspose.Slides erhält die Listformatierung, wenn das Zielformat die entsprechenden Textlayout‑ und Aufzählungs‑Funktionen unterstützt.

**Kann ich Listen in vorhandenen Präsentationen bearbeiten?**

Ja. Laden Sie die Präsentation, greifen Sie auf den Zielabsatz zu, prüfen oder aktualisieren Sie dessen [ParagraphFormat.getBullet](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#getBullet)-Einstellungen und speichern Sie die Präsentation.

**Können Listen nicht‑lateinischen Text enthalten?**

Ja. Der Text eines Listeneintrags kann Unicode‑Zeichen enthalten, sodass Sie Listen in mehrsprachigen Präsentationen erstellen können. Stellen Sie sicher, dass die in der Präsentation verwendeten Schriftarten die benötigten Zeichen unterstützen.