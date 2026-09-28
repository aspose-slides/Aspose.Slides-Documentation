---
title: Zástupný obrázek náhledu objektu při přidání OleObjectFrame
linktitle: Zástupný obrázek náhledu OLE
type: docs
weight: 10
url: /cs/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problém s náhledem
- zástupný obrázek náhledu
- záměrně
- vložený objekt
- vložený soubor
- objekt změněn
- náhled objektu
- prezentace
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Proč OLE objekt přidaný pomocí Aspose.Slides pro .NET zobrazuje zástupný obrázek EMBEDDED OLE OBJECT, dokud není aktualizován jeho náhled, a jak nastavit vlastní náhledový obrázek."
---
## **Úvod**

Při použití Aspose.Slides pro .NET, když přidáte [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/) na snímek, na výstupním snímku se zobrazí zpráva „EMBEDDED OLE OBJECT“. Tato zpráva je záměrná a NENÍ chyba.

Pro více informací o práci s OLE objekty viz [Manage OLE](/slides/cs/net/manage-ole/).

## **Vysvětlení a řešení**

Aspose.Slides zobrazuje zprávu „EMBEDDED OLE OBJECT“, aby vás upozornil, že OLE objekt byl změněn a náhledový obrázek musí být aktualizován.

Například pokud přidáte graf Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/) na snímek (pro podrobnosti viz článek „Manage OLE“) a poté otevřete prezentaci v Microsoft PowerPoint, uvidíte na snímku tento obrázek:

![OLE object message](OLE_object_message.png)

Pokud chcete zkontrolovat a potvrdit, že byl váš OLE objekt přidán na snímek, musíte dvakrát kliknout na zprávu „EMBEDDED OLE OBJECT“, nebo na ni můžete kliknout pravým tlačítkem a zvolit **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint poté otevře vložený OLE objekt.

![OLE object data](OLE_object_data.png)

Snímek může zachovat zprávu „EMBEDDED OLE OBJECT“. Jakmile kliknete na OLE objekt, náhled snímku se aktualizuje a zpráva „EMBEDDED OLE OBJECT“ je nahrazena skutečným obrázkem OLE objektu.

![OLE object preview](OLE_object_preview.png)

Nyní můžete chtít prezentaci uložit, aby se obrázek OLE objektu správně aktualizoval. Tímto způsobem po uložení prezentace, když ji znovu otevřete, nebudete vidět zprávu „EMBEDDED OLE OBJECT“.

## **Další řešení**

### **Řešení 1: Nahradit zprávu „Embedded OLE Object“ obrázkem**

Pokud nechcete odstranit zprávu „EMBEDDED OLE OBJECT“ otevřením prezentace v PowerPointu a jejím uložením, můžete zprávu nahradit vámi preferovaným náhledovým obrázkem. Tyto řádky kódu ukazují proces:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set the image for the OLE object preview.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

Snímek obsahující `OleObjectFrame` se pak změní na toto:

![New OLE object image](OLE_object_new_image.png)

### **Řešení 2: Vytvořit doplněk pro PowerPoint**

Můžete také vytvořit doplněk pro Microsoft PowerPoint, který aktualizuje všechny OLE objekty při otevření prezentací v programu.