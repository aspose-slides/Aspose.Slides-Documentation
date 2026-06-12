---
title: Problém s náhledem objektu při přidání OleObjectFrame
linktitle: Problém s OLE objektem
type: docs
weight: 10
url: /cs/cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problém s náhledem
- vložený objekt
- vložený soubor
- objekt změněn
- náhled objektu
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, proč se při přidávání OleObjectFrame v Aspose.Slides pro C++ objevuje zpráva EMBEDDED OLE OBJECT a jak opravit problémy s náhledem v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Při použití Aspose.Slides pro C++, když do snímku přidáte [OleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/), zobrazí se na výstupním snímku zpráva „EMBEDDED OLE OBJECT“. Tato zpráva je úmyslná a NEJDE o chybu.

Další informace o práci s OLE objekty najdete v článku [Spravovat OLE](/slides/cs/cpp/manage-ole/). 

## **Vysvětlení a řešení**

Aspose.Slides zobrazuje zprávu „EMBEDDED OLE OBJECT“, aby vás upozornil, že OLE objekt byl změněn a náhledový obrázek je třeba aktualizovat. 

Například pokud do snímku přidáte graf Excelu jako [OleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/) (více podrobností v článku „Spravovat OLE“) a poté otevřete prezentaci v Microsoft PowerPoint, uvidíte na snímku tento obrázek:

![Zpráva OLE objektu](OLE_object_message.png)

Chcete‑li zkontrolovat a potvrdit, že byl OLE objekt přidán do snímku, musíte dvojkliknout na zprávu „EMBEDDED OLE OBJECT“ nebo na ni pravým tlačítkem vybrat **Objekt > Upravit**.

![OLE objekt > Upravit](OLE_object_edit.png)

PowerPoint pak otevře vložený OLE objekt.

![Data OLE objektu](OLE_object_data.png)

Snímek může zprávu „EMBEDDED OLE OBJECT“ zachovat. Jakmile však objekt OLE kliknete, náhled snímku se aktualizuje a zpráva „EMBEDDED OLE OBJECT“ je nahrazena skutečným obrázkem OLE objektu. 

![Náhled OLE objektu](OLE_object_preview.png)

Nyní můžete prezentaci uložit, aby se obrázek OLE objektu správně aktualizoval. Po uložení a opětovném otevření prezentace už nebudete vidět zprávu „EMBEDDED OLE OBJECT“. 

## **Další řešení**

### **Řešení 1: Nahradit zprávu „Embedded OLE Object“ obrázkem**

Pokud nechcete odstraňovat zprávu „EMBEDDED OLE OBJECT“ otevřením prezentace v PowerPointu a jejím uložením, můžete zprávu nahradit vámi preferovaným náhledovým obrázkem. Následující řádky kódu ukazují postup:

```cpp
auto presentation = MakeObject<Presentation>(u"embeddedOLE.pptx");

auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to presentation resources.
auto imageStream = File::OpenRead(u"myImage.png");
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Set a title and the image for the OLE object preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"embeddedOLE-newImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Snímek obsahující `OleObjectFrame` pak vypadá takto:

![Nový obrázek OLE objektu](OLE_object_new_image.png)

### **Řešení 2: Vytvořit doplněk pro PowerPoint**

Můžete také vytvořit doplněk pro Microsoft PowerPoint, který při otevření prezentací v programu aktualizuje všechny OLE objekty.