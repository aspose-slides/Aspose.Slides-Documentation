---
title: Problém s náhledem objektu při přidání OleObjectFrame
linktitle: Problém s OLE objektem
type: docs
weight: 10
url: /cs/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
  - OLE
  - problém s náhledem
  - vložený objekt
  - vložený soubor
  - objekt změněn
  - náhled objektu
  - prezentace
  - PowerPoint
  - .NET
  - C#
  - Aspose.Slides
description: "Zjistěte, proč se při přidání OleObjectFrame v Aspose.Slides pro .NET objeví zpráva EMBEDDED OLE OBJECT a jak opravit problémy s náhledem v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Při použití Aspose.Slides pro .NET, když přidáte [OleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe) na snímek, na výstupním snímku se zobrazí zpráva „EMBEDDED OLE OBJECT“. Tato zpráva je úmyslná a NEJDE o chybu.

Pro více informací o práci s OLE objekty viz [Správa OLE](/slides/cs/net/manage-ole/).

## **Vysvětlení a řešení**

Aspose.Slides zobrazuje zprávu „EMBEDDED OLE OBJECT“, aby vás upozornil, že OLE objekt byl změněn a předběžný obrázek je třeba aktualizovat.

Například pokud přidáte graf Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/oleobjectframe) na snímek (pro podrobnosti viz článek „Manage OLE“) a poté otevřete prezentaci v Microsoft PowerPoint, uvidíte na snímku tento obrázek:

![Zpráva OLE objektu](OLE_object_message.png)

Pokud chcete zkontrolovat a potvrdit, že byl váš OLE objekt přidán na snímek, musíte dvakrát kliknout na zprávu „EMBEDDED OLE OBJECT“, nebo na ni kliknout pravým tlačítkem a zvolit možnost **Object > Edit**.

![OLE objekt > Upravit](OLE_object_edit.png)

PowerPoint poté otevře vložený OLE objekt.

![Data OLE objektu](OLE_object_data.png)

Snímek může nadále zobrazovat zprávu „EMBEDDED OLE OBJECT“. Po kliknutí na OLE objekt se náhled snímku aktualizuje a zpráva „EMBEDDED OLE OBJECT“ je nahrazena skutečným obrázkem OLE objektu.

![Náhled OLE objektu](OLE_object_preview.png)

Nyní můžete chtít uložit prezentaci, aby se obrázek OLE objektu správně aktualizoval. Tímto způsobem, po uložení prezentace, když ji znovu otevřete, už nebudete vidět zprávu „EMBEDDED OLE OBJECT“.

## **Další řešení**

### **Řešení 1: Nahradit zprávu „Embedded OLE Object“ obrázkem**

Pokud nechcete odstranit zprávu „EMBEDDED OLE OBJECT“ otevřením prezentace v PowerPoint a jejím následným uložením, můžete zprávu nahradit vámi preferovaným náhledovým obrázkem. Následující řádky kódu ukazují postup:

```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set a title and the image for the OLE object preview.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

Snímek obsahující `OleObjectFrame` pak vypadá takto:

![Nový obrázek OLE objektu](OLE_object_new_image.png)

### **Řešení 2: Vytvořit doplněk pro PowerPoint**

Můžete také vytvořit doplněk pro Microsoft PowerPoint, který aktualizuje všechny OLE objekty při otevření prezentací v programu.