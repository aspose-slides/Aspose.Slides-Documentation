---
title: Problém s náhledem objektu při přidání OleObjectFrame
linktitle: Problém s OLE objektem
type: docs
weight: 10
url: /cs/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problém s náhledem
- vložený objekt
- vložený soubor
- objekt změněn
- náhled objektu
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, proč se při přidání OleObjectFrame v Aspose.Slides pro Java zobrazí zpráva EMBEDDED OLE OBJECT a jak opravit problémy s náhledem v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Při používání Aspose.Slides pro Java, když do snímku přidáte [OleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/oleobjectframe/), objeví se na výstupním snímku zpráva „EMBEDDED OLE OBJECT“. Tato zpráva je úmyslná a NEJDE o chybu.

Další informace o práci s OLE objekty naleznete v článku [Manage OLE](/slides/cs/java/manage-ole/). 

## **Vysvětlení a řešení**

Aspose.Slides zobrazuje zprávu „EMBEDDED OLE OBJECT“, aby vás upozornil, že OLE objekt byl změněn a náhledový obrázek je potřeba aktualizovat. 

Například pokud do snímku přidáte graf Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/oleobjectframe/) (pro podrobnosti viz článek „Manage OLE“) a poté otevřete prezentaci v Microsoft PowerPoint, uvidíte na snímku tento obrázek:

![Zpráva OLE objektu](OLE_object_message.png)

Pokud chcete zkontrolovat a potvrdit, že byl váš OLE objekt přidán do snímku, musíte dvakrát kliknout na zprávu „EMBEDDED OLE OBJECT“, nebo na ni kliknout pravým tlačítkem a zvolit možnost **Object > Edit**.

![OLE objekt > Upravit](OLE_object_edit.png)

PowerPoint poté otevře vložený OLE objekt.

![Data OLE objektu](OLE_object_data.png)

Snímek může zprávu „EMBEDDED OLE OBJECT“ zachovat. Jakmile kliknete na OLE objekt, náhled snímku se aktualizuje a zpráva „EMBEDDED OLE OBJECT“ bude nahrazena skutečným obrázkem OLE objektu. 

![Náhled OLE objektu](OLE_object_preview.png)

Nyní můžete chtít uložit prezentaci, aby se obrázek OLE objektu správně aktualizoval. Tím zajistíte, že po uložení prezentace a jejím opětovném otevření nebudete vidět zprávu „EMBEDDED OLE OBJECT“. 

## **Další řešení**

### **Řešení 1: Nahradit zprávu „Embedded OLE Object“ obrázkem**

Pokud nechcete odstranit zprávu „EMBEDDED OLE OBJECT“ otevřením prezentace v PowerPointu a jejím následným uložením, můžete zprávu nahradit preferovaným náhledovým obrázkem. Následující řádky kódu ukazují postup:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Přidat obrázek do zdrojů prezentace.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Nastavit titulek a obrázek pro náhled OLE objektu.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

Snímek obsahující `OleObjectFrame` se poté změní na tento:

![Nový obrázek OLE objektu](OLE_object_new_image.png)

### **Řešení 2: Vytvořit doplněk pro PowerPoint**

Můžete také vytvořit doplněk pro Microsoft PowerPoint, který při otevření prezentací v programu aktualizuje všechny OLE objekty.