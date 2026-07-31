---
title: Problém s náhledem objektu při přidání OleObjectFrame
linktitle: Problém s OLE objektem
type: docs
weight: 10
url: /cs/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
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
description: "Zjistěte, proč se při přidání OleObjectFrame v Aspose.Slides pro Node.js zobrazuje zpráva EMBEDDED OLE OBJECT a jak opravit problémy s náhledem v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Pomocí Aspose.Slides pro Java, když přidáte [OleObjectFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/oleobjectframe/) na snímek, na výstupním snímku se zobrazí zpráva „EMBEDDED OLE OBJECT“. Tato zpráva je úmyslná a NENÍ chyba.

Další informace o práci s objekty OLE najdete v [Manage OLE](/slides/cs/nodejs-java/manage-ole/). 

## **Vysvětlení a řešení**

Aspose.Slides zobrazuje zprávu „EMBEDDED OLE OBJECT“, aby vás upozornil, že objekt OLE byl změněn a je třeba aktualizovat náhledový obrázek. 

Například pokud přidáte graf Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/oleobjectframe/) na snímek (pro podrobnosti viz článek „Manage OLE“) a poté otevřete prezentaci v Microsoft PowerPoint, uvidíte na snímku tento obrázek:

![Zpráva OLE objektu](OLE_object_message.png)

Pokud chcete zkontrolovat a potvrdit, že byl váš OLE objekt přidán na snímek, musíte dvojitě kliknout na zprávu „EMBEDDED OLE OBJECT“, nebo můžete na ni kliknout pravým tlačítkem a zvolit možnost **Object > Edit**.

![OLE objekt > Upravit](OLE_object_edit.png)

PowerPoint poté otevře vložený OLE objekt.

![Data OLE objektu](OLE_object_data.png)

Snímek může nadále zobrazovat zprávu „EMBEDDED OLE OBJECT“. Jakmile na OLE objekt kliknete, náhled snímku se aktualizuje a zpráva „EMBEDDED OLE OBJECT“ je nahrazena skutečným obrázkem OLE objektu. 

![Náhled OLE objektu](OLE_object_preview.png)

Nyní můžete chtít prezentaci uložit, aby se obrázek OLE objektu správně aktualizoval. Tímto způsobem, po uložení prezentace, když ji znovu otevřete, nebudete vidět zprávu „EMBEDDED OLE OBJECT“. 

## **Další řešení**

### **Řešení 1: Nahradit zprávu „Embedded OLE Object“ obrázkem**

Pokud nechcete zprávu „EMBEDDED OLE OBJECT“ odstranit otevřením prezentace v PowerPointu a jejím uložením, můžete ji nahradit svým preferovaným náhledovým obrázkem. Tyto řádky kódu ukazují postup:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Přidat obrázek do zdrojů prezentace.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Nastavit název a obrázek pro náhled OLE objektu.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Snímek obsahující `OleObjectFrame` se následně změní na tento:

![Nový obrázek OLE objektu](OLE_object_new_image.png)

### **Řešení 2: Vytvořit doplněk pro PowerPoint**

Můžete také vytvořit doplněk pro Microsoft PowerPoint, který aktualizuje všechny OLE objekty při otevření prezentací v programu.