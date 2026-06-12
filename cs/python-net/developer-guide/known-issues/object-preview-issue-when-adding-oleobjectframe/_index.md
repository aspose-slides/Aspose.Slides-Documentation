---
title: Problém s náhledem objektu při přidávání OleObjectFrame
linktitle: Problém s OLE objektem
type: docs
weight: 10
url: /cs/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problém s náhledem
- vložený objekt
- vložený soubor
- objekt změněn
- náhled objektu
- prezentace
- PowerPoint
- Python
- Aspose.Slides
description: "Zjistěte, proč se při přidávání OleObjectFrame v Aspose.Slides pro Python zobrazuje zpráva EMBEDDED OLE OBJECT a jak opravit problémy s náhledem v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Při používání Aspose.Slides pro Python přes .NET, když přidáte [OleObjectFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/oleobjectframe/) na snímek, zobrazí se na výstupním snímku zpráva „EMBEDDED OLE OBJECT“. Tato zpráva je úmyslná a NEJDE o chybu.

Pro více informací o práci s OLE objekty, viz [Správa OLE](/slides/cs/python-net/manage-ole/). 

## **Vysvětlení a řešení**

Aspose.Slides zobrazuje zprávu „EMBEDDED OLE OBJECT“, aby vás upozornil, že OLE objekt byl změněn a náhledový obrázek je třeba aktualizovat. 

Například pokud přidáte graf Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/oleobjectframe/) na snímek (více podrobností najdete v článku „Správa OLE“) a pak otevřete prezentaci v Microsoft PowerPoint, uvidíte na snímku tento obrázek:

![Zpráva OLE objektu](OLE_object_message.png)

Pokud chcete zkontrolovat a potvrdit, že byl váš OLE objekt přidán na snímek, musíte dvakrát kliknout na zprávu „EMBEDDED OLE OBJECT“, nebo na ni můžete kliknout pravým tlačítkem myši a zvolit možnost **Objekt > Upravit**.

![OLE objekt > Upravit](OLE_object_edit.png)

PowerPoint pak otevře vložený OLE objekt.

![Data OLE objektu](OLE_object_data.png)

Snímek může nadále zobrazovat zprávu „EMBEDDED OLE OBJECT“. Jakmile kliknete na OLE objekt, náhled snímku se aktualizuje a zpráva „EMBEDDED OLE OBJECT“ je nahrazena skutečným obrázkem OLE objektu. 

![Náhled OLE objektu](OLE_object_preview.png)

Nyní můžete chtít prezentaci uložit, aby se obrázek OLE objektu správně aktualizoval. Tímto způsobem, po uložení prezentace a jejím opětovném otevření, NEUVIDÍTE zprávu „EMBEDDED OLE OBJECT“. 

## **Další řešení**

### **Řešení 1: Nahradit zprávu „Embedded OLE Object“ obrázkem**

Pokud nechcete odstranit zprávu „EMBEDDED OLE OBJECT“ otevřením prezentace v PowerPointu a jejím následným uložením, můžete zprávu nahradit vámi preferovaným náhledovým obrázkem. Následující řádky kódu ukazují postup:

```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Přidejte obrázek do zdrojů prezentace.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Nastavte nadpis a obrázek pro náhled OLE objektu.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```

Snímek obsahující `OleObjectFrame` se poté změní na následující:

![Nový obrázek OLE objektu](OLE_object_new_image.png)

### **Řešení 2: Vytvořit doplněk pro PowerPoint**

Můžete také vytvořit doplněk pro Microsoft PowerPoint, který aktualizuje všechny OLE objekty při otevírání prezentací v programu.