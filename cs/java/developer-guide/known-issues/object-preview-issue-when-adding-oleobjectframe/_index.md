---
title: Zástupná značka náhledu objektu při přidání OleObjectFrame
linktitle: Zástupná značka náhledu OLE
type: docs
weight: 10
url: /cs/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problém s náhledem
- zástupná značka náhledu
- záměrně
- vložený objekt
- vložený soubor
- objekt změněn
- náhled objektu
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Proč OLE objekt přidaný pomocí Aspose.Slides for Java zobrazuje zástupnou značku EMBEDDED OLE OBJECT, dokud není jeho náhled aktualizován, a jak nastavit vlastní obrázek náhledu."
---
## **Úvod**

Pomocí Aspose.Slides for Java, když přidáte [OleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/oleobjectframe/) na snímek, zobrazí se na výstupním snímku zpráva "EMBEDDED OLE OBJECT". Tato zpráva je úmyslná a NOT a bug.

Další informace o práci s OLE objekty najdete v [Manage OLE](/slides/cs/java/manage-ole/).

## **Vysvětlení a řešení**

Aspose.Slides zobrazuje zprávu "EMBEDDED OLE OBJECT", aby vás upozornil, že OLE objekt byl změněn a náhledový obrázek je třeba aktualizovat.

Například pokud přidáte graf Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/oleobjectframe/) na snímek (pro podrobnosti viz článek "Manage OLE") a poté otevřete prezentaci v Microsoft PowerPoint, uvidíte na snímku tento obrázek:

![OLE object message](OLE_object_message.png)

Pokud chcete zkontrolovat a potvrdit, že byl Váš OLE objekt přidán na snímek, musíte dvakrát kliknout na zprávu "EMBEDDED OLE OBJECT", nebo na ni kliknout pravým tlačítkem a zvolit možnost **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint poté otevře vložený OLE objekt.

![OLE object data](OLE_object_data.png)

Snímek může nadále zobrazovat zprávu "EMBEDDED OLE OBJECT". Jakmile kliknete na OLE objekt, náhled snímku se aktualizuje a zpráva "EMBEDDED OLE OBJECT" je nahrazena skutečným obrázkem OLE objektu.

![OLE object preview](OLE_object_preview.png)

Nyní možná budete chtít uložit prezentaci, aby se obrázek OLE objektu správně aktualizoval. Tímto způsobem, po uložení prezentace, když ji znovu otevřete, nebudete vidět zprávu "EMBEDDED OLE OBJECT".

## **Další řešení**

Pokud nechcete odstranit zprávu "EMBEDDED OLE OBJECT" otevřením prezentace v PowerPointu a jejím uložením, můžete zprávu nahradit preferovaným náhledovým obrázkem. Následující řádky kódu demonstrují tento proces. Předpokládají, že první tvar na prvním snímku souboru *embeddedOLE.pptx* je rámec OLE objektu a že *myImage.png* obsahuje obrázek k zobrazení, a výsledek uloží jako *embeddedOLE-newImage.pptx*:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Přidejte obrázek do zdrojů prezentace.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // Nastavte obrázek pro náhled OLE objektu.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Snímek obsahující `OleObjectFrame` se poté změní na tento:

![New OLE object image](OLE_object_new_image.png)