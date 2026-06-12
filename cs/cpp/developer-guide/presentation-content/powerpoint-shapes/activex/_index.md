---
title: Správa ActiveX ovládacích prvků v prezentacích pomocí C++
linktitle: ActiveX
type: docs
weight: 80
url: /cs/cpp/activex/
keywords:
- ActiveX
- ActiveX ovládací prvek
- správa ActiveX
- přidání ActiveX
- úprava ActiveX
- multimediální přehrávač
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, jak Aspose.Slides pro C++ využívá ActiveX k automatizaci a vylepšení prezentací PowerPoint, a poskytuje vývojářům silnou kontrolu nad snímky."
---
## **Úvod**

ActiveX ovládací prvky se používají v prezentacích. Aspose.Slides pro C++ vám umožňuje spravovat ActiveX ovládací prvky, ale jejich správa je o něco složitější a liší se od běžných tvarů v prezentaci. Od Aspose.Slides pro C++ 18.1 komponenta podporuje správu ActiveX ovládacích prvků. V současné době můžete přistupovat k již přidanému ActiveX ovládacímu prvku v prezentaci a upravovat jej nebo jej smazat pomocí jeho různých vlastností. Pamatujte, že ActiveX ovládací prvky nejsou tvary a nejsou součástí IShapeCollection prezentace, ale samostatné IControlCollection. Tento článek ukazuje, jak s nimi pracovat.

## **Upravit ActiveX ovládací prvek**

1. Vytvořte instanci třídy Presentation a načtěte prezentaci, která obsahuje ActiveX ovládací prvky.  
2. Získejte referenci na snímek podle jeho indexu.  
3. Přistupujte k ActiveX ovládacím prvkům na snímku pomocí IControlCollection.  
4. Získejte ActiveX ovládací prvek TextBox1 pomocí objektu ControlEx.  
5. Změňte různé vlastnosti ActiveX ovládacího prvku TextBox1, včetně textu, písma, výšky písma a pozice rámce.  
6. Získejte druhý ovládací prvek nazvaný CommandButton1.  
7. Změňte popisek tlačítka, písmo a pozici.  
8. Posuňte pozici rámců ActiveX ovládacích prvků.  
9. Uložte upravenou prezentaci do souboru PPTX.

Níže uvedený úryvek kódu aktualizuje ActiveX ovládací prvky na snímcích prezentace podle snímku zobrazeného níže.

```cpp
// Přístup k prezentaci s ActiveX ovládacími prvky
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Přístup k prvnímu snímku v prezentaci
auto slide = presentation->get_Slides()->idx_get(0);

// Změna textu TextBoxu
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // Změna náhradního obrázku. PowerPoint tento obrázek nahradí během aktivace ActiveX, takže je někdy v pořádku nechat obrázek beze změny.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// Změna popisku tlačítka
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // Změna náhrady
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// Posunutí rámců ActiveX o 100 bodů dolů
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// Uložení prezentace s upravenými ActiveX ovládacími prvky
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Nyní odstraňování ovládacích prvků
slide->get_Controls()->Clear();

// Ukládání prezentace s vymazanými ActiveX ovládacími prvky
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Přidat Media Player ActiveX ovládací prvek**

ActiveX ovládací prvky se používají v prezentacích. Aspose.Slides pro C++ vám umožňuje přidávat a spravovat ActiveX ovládací prvky, ale jejich správa je o něco složitější a liší se od běžných tvarů v prezentaci. Od Aspose.Slides pro C++ 18.1 byla do Aspose.Slides přidána podpora pro přidání Media Player ActiveX ovládacího prvku. Pamatujte, že ActiveX ovládací prvky nejsou tvary a nejsou součástí IShapeCollection prezentace, ale samostatné IControlExCollection. Tento článek ukazuje, jak s nimi pracovat. Pro správu Media Player ActiveX ovládacího prvku postupujte podle následujících kroků:

1. Vytvořte instanci třídy Presentation a načtěte ukázkovou prezentaci, která obsahuje Media Player ActiveX ovládací prvky.  
2. Vytvořte instanci cílové třídy Presentation a vytvořte prázdnou prezentaci.  
3. Naklonujte snímek s Media Player ActiveX ovládacím prvkem z šablonové prezentace do cílové prezentace.  
4. Získejte přístup ke klonovanému snímku v cílové prezentaci.  
5. Přistupujte k ActiveX ovládacím prvkům na snímku pomocí IControlCollection.  
6. Získejte Media Player ActiveX ovládací prvek a nastavte cestu k videu pomocí jeho vlastností.  
7. Uložte prezentaci do souboru PPTX.

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Vytvořte prázdnou instanci prezentace
auto newPresentation = System::MakeObject<Presentation>();

// Odstraňte výchozí snímek
newPresentation->get_Slides()->RemoveAt(0);

// Naklonujte snímek s Media Player ActiveX ovládacím prvkem
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Získejte přístup k Media Player ActiveX ovládacímu prvku a nastavte cestu k videu
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Uložte prezentaci
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```

## **Často kladené otázky**

**Zachovává Aspose.Slides ActiveX ovládací prvky při načítání a opětovném ukládání, pokud není možné je spustit v runtime C++?**  
Ano. Aspose.Slides je považuje za součást prezentace a může číst/upravovat jejich vlastnosti a rámce; není vyžadováno spouštění samotných ovládacích prvků pro jejich zachování.

**Jak se ActiveX ovládací prvky liší od OLE objektů v prezentaci?**  
ActiveX ovládací prvky jsou interaktivní řízené prvky (tlačítka, textová pole, media player), zatímco [OLE](/slides/cs/cpp/manage-ole/) odkazuje na vložené objekty aplikací (například list Excel). Jsou ukládány a zpracovávány odlišně a mají odlišné modely vlastností.

**Fungují ActiveX události a VBA makra, pokud byl soubor upraven pomocí Aspose.Slides?**  
Aspose.Slides zachovává existující značkování a metadata; nicméně události a makra se spouští pouze v PowerPointu na Windows, pokud to bezpečnostní nastavení povolí. Knihovna nespouští VBA.