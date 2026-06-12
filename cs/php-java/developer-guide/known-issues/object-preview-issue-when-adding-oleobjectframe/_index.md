---
title: Problém s náhledem objektu při přidávání OleObjectFrame
linktitle: Problém s OLE objektem
type: docs
weight: 10
url: /cs/php-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problém s náhledem
- vložený objekt
- vložený soubor
- objekt změněn
- náhled objektu
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Zjistěte, proč se při přidávání OleObjectFrame v Aspose.Slides pro PHP zobrazuje EMBEDDED OLE OBJECT a jak opravit problémy s náhledem v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Při použití Aspose.Slides pro PHP přes Java, když přidáte [OleObjectFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/oleobjectframe/) do snímku, zobrazí se na výstupním snímku zpráva "EMBEDDED OLE OBJECT". Tato zpráva je záměrná a NOT a bug.

Další informace o práci s OLE objekty najdete v článku [Manage OLE](/slides/cs/php-java/manage-ole/). 

## **Vysvětlení a řešení**

Aspose.Slides zobrazí zprávu "EMBEDDED OLE OBJECT", aby vás upozornil, že OLE objekt byl změněn a náhledový obrázek je potřeba aktualizovat. 

Například pokud do snímku přidáte graf Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/oleobjectframe/) (pro podrobnosti viz článek "Manage OLE") a poté otevřete prezentaci v Microsoft PowerPoint, uvidíte na snímku tento obrázek:

![OLE object message](OLE_object_message.png)

Pokud chcete zkontrolovat a potvrdit, že byl váš OLE objekt přidán do snímku, musíte dvakrát kliknout na zprávu "EMBEDDED OLE OBJECT", nebo na ni pravým tlačítkem a zvolit možnost **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint poté otevře vložený OLE objekt.

![OLE object data](OLE_object_data.png)

Snímek může stále zobrazovat zprávu "EMBEDDED OLE OBJECT". Jakmile na OLE objekt kliknete, náhled snímku se aktualizuje a zpráva "EMBEDDED OLE OBJECT" je nahrazena skutečným obrázkem OLE objektu. 

![OLE object preview](OLE_object_preview.png)

Nyní můžete chtít uložit prezentaci, aby se obrázek OLE objektu správně aktualizoval. Tím, po uložení prezentace, když ji znovu otevřete, již neuvidíte zprávu "EMBEDDED OLE OBJECT". 

## **Další řešení**

### **Řešení 1: Nahraďte zprávu „Embedded OLE Object“ obrázkem**

Pokud nechcete odstranit zprávu "EMBEDDED OLE OBJECT" otevřením prezentace v PowerPointu a jejím uložením, můžete zprávu nahradit vámi preferovaným náhledovým obrázkem. Následující řádky kódu ukazují postup:

```php
$presentation = new Presentation("embeddedOLE.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $oleFrame = $slide->getShapes()->get_Item(0);

    // Přidejte obrázek do zdrojů prezentace.
    $image = Images::fromFile("myImage.png");
    $oleImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Nastavte název a obrázek pro náhled OLE objektu.
    $oleFrame->setSubstitutePictureTitle("My title");
    $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleFrame->setObjectIcon(false);

    $presentation->save("embeddedOLE-newImage.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Snímek obsahující `OleObjectFrame` se následně změní na:

![New OLE object image](OLE_object_new_image.png)

### **Řešení 2: Vytvořte doplněk pro PowerPoint**

Můžete také vytvořit doplněk pro Microsoft PowerPoint, který při otevření prezentací v programu aktualizuje všechny OLE objekty.