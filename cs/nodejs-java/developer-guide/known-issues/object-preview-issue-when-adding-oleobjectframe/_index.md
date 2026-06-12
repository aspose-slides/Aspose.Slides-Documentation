---
title: Problém s náhledem objektu při přidání OleObjectFrame
linktitle: Problém s OLE objektem
type: docs
weight: 10
url: /cs/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problém s náhledem
- vložený objekt
- vložený soubor
- objekt změněn
- náhled objektu
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Zjistěte, proč se při přidání OleObjectFrame v Aspose.Slides pro Node.js zobrazí zpráva EMBEDDED OLE OBJECT a jak opravit problémy s náhledem v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Používáte-li Aspose.Slides pro Java a přidáte na snímek [OleObjectFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/oleobjectframe/), zobrazí se na výstupním snímku zpráva „EMBEDDED OLE OBJECT“. Tato zpráva je úmyslná a NEJDE o chybu.

Další informace o práci s OLE objekty najdete v [Manage OLE](/slides/cs/nodejs-java/manage-ole/).

## **Vysvětlení a řešení**

Aspose.Slides zobrazuje zprávu „EMBEDDED OLE OBJECT“, aby vás upozornil, že OLE objekt byl změněn a náhledový obrázek je třeba aktualizovat.

Například pokud přidáte graf Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/oleobjectframe/) na snímek (další podrobnosti v článku „Manage OLE“) a poté otevřete prezentaci v Microsoft PowerPoint, uvidíte na snímku tento obrázek:

![OLE object message](OLE_object_message.png)

Chcete-li zkontrolovat a potvrdit, že byl váš OLE objekt přidán na snímek, musíte dvojkliknout na zprávu „EMBEDDED OLE OBJECT“ nebo na ni kliknout pravým tlačítkem myši a zvolit **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint pak otevře vložený OLE objekt.

![OLE object data](OLE_object_data.png)

Snímek může zprávu „EMBEDDED OLE OBJECT“ zachovat. Jakmile na OLE objekt kliknete, aktualizuje se náhled snímku a zpráva „EMBEDDED OLE OBJECT“ se nahradí skutečným obrázkem OLE objektu.

![OLE object preview](OLE_object_preview.png)

Nyní možná chcete prezentaci uložit, aby se obrázek OLE objektu správně aktualizoval. Po uložení prezentace se při jejím opětovném otevření zpráva „EMBEDDED OLE OBJECT“ již nezobrazí.

## **Další řešení**

### **Řešení 1: Nahradit zprávu „Embedded OLE Object“ obrázkem**

Pokud nechcete odstraňovat zprávu „EMBEDDED OLE OBJECT“ otevřením prezentace v PowerPointu a jejím uložením, můžete zprávu nahradit preferovaným náhledovým obrázkem. Následující řádky kódu ukazují postup:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Přidejte obrázek do zdrojů prezentace.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Nastavte název a obrázek pro náhled OLE objektu.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Snímek obsahující `OleObjectFrame` pak vypadá takto:

![New OLE object image](OLE_object_new_image.png)

### **Řešení 2: Vytvořit doplněk pro PowerPoint**

Můžete také vytvořit doplněk pro Microsoft PowerPoint, který při otevření prezentací v programu aktualizuje všechny OLE objekty.