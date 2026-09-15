---
title: Problém s náhledem objektu při přidávání OleObjectFrame
linktitle: Problém s OLE objektem
type: docs
weight: 10
url: /cs/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problém s náhledem
- vložený objekt
- vložený soubor
- objekt změněn
- náhled objektu
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Zjistěte, proč se při přidávání OleObjectFrame v Aspose.Slides pro Python via Java zobrazuje zpráva EMBEDDED OLE OBJECT a jak opravit problémy s náhledem v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Když používáte Aspose.Slides for Python via Java k přidání [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/) na snímek, zobrazí se na výstupním snímku zpráva „EMBEDDED OLE OBJECT“. Tato zpráva je úmyslná a nejedná se o chybu.

Další informace o práci s OLE objekty najdete v článku [Správa OLE](/slides/cs/python-java/manage-ole/).

## **Vysvětlení a řešení**

Aspose.Slides zobrazuje zprávu „EMBEDDED OLE OBJECT“, aby vás upozornil, že OLE objekt byl změněn a náhledový obrázek je třeba aktualizovat.

Například pokud přidáte graf Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/) na snímek (pro podrobnosti viz článek „Správa OLE“) a potom otevřete prezentaci v Microsoft PowerPoint, uvidíte na snímku následující obrázek:

![Zpráva OLE objektu](OLE_object_message.png)

Pro ověření, že byl OLE objekt přidán na snímek, dvojklikněte na zprávu „EMBEDDED OLE OBJECT“ nebo na ni klikněte pravým tlačítkem a vyberte **Object > Edit**.

![OLE objekt > Úpravy](OLE_object_edit.png)

PowerPoint následně otevře vložený OLE objekt.

![Data OLE objektu](OLE_object_data.png)

Snímek může i nadále obsahovat zprávu „EMBEDDED OLE OBJECT“. Jakmile na OLE objekt kliknete, náhled snímku se aktualizuje a zpráva „EMBEDDED OLE OBJECT“ je nahrazena skutečným obrázkem OLE objektu.

![Náhled OLE objektu](OLE_object_preview.png)

Uložte prezentaci, aby se zachoval aktualizovaný náhledový obrázek OLE objektu. Při dalším otevření prezentace již zprávu „EMBEDDED OLE OBJECT“ neuvidíte.

## **Další řešení**

Pokud nechcete odstranit zprávu „EMBEDDED OLE OBJECT“ otevřením prezentace v PowerPointu a jejím uložením, můžete zprávu nahradit vámi preferovaným náhledovým obrázkem. Následující kód demonstruje postup:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Přidejte obrázek do zdrojů prezentace.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Nastavte název a obrázek pro náhled OLE objektu.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Snímek obsahující [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/) se pak změní na:

![Nový obrázek OLE objektu](OLE_object_new_image.png)

## **Často kladené otázky**

**Proč se zobrazuje zpráva „EMBEDDED OLE OBJECT“?**

Zpráva uvádí, že OLE objekt byl změněn a jeho náhledový obrázek je potřeba aktualizovat. Toto chování je úmyslné.

**Jak mohu aktualizovat náhled v PowerPointu?**

Dvojklikněte na zprávu nebo vyberte **Object > Edit**, čímž otevřete vložený OLE objekt. Klikněte na OLE objekt pro aktualizaci náhledu a poté prezentaci uložte.

**Mohu nahradit zprávu bez otevření prezentace v PowerPointu?**

Ano. Můžete přiřadit preferovaný náhledový obrázek OLE objektu, jak je ukázáno v příkladu kódu výše.