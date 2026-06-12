---
title: Správa ActiveX ovládacích prvků v prezentacích v .NET
linktitle: ActiveX
type: docs
weight: 80
url: /cs/net/activex/
keywords:
- ActiveX
- ActiveX kontrola
- správa ActiveX
- přidání ActiveX
- úprava ActiveX
- mediální přehrávač
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak Aspose.Slides pro .NET využívá ActiveX k automatizaci a vylepšení prezentací PowerPoint, poskytuje vývojářům silnou kontrolu nad snímky."
---
## **Úvod**

ActiveX ovládací prvky se používají v prezentacích. Aspose.Slides pro .NET vám umožňuje spravovat ActiveX ovládací prvky, ale jejich správa je trochu složitější a liší se od běžných tvarů v prezentaci. Od Aspose.Slides pro .NET 6.9.0 komponent podporuje správu ActiveX ovládacích prvků. V současné době můžete v prezentaci získat přístup k již přidanému ActiveX ovládacímu prvku a pomocí jeho různých vlastností ho upravit nebo smazat. Pamatujte, že ActiveX ovládací prvky nejsou tvary a nejsou součástí IShapeCollection prezentace, ale samostatného IControlCollection. Tento článek ukazuje, jak s nimi pracovat.

## **Upravit ActiveX ovládací prvky**

Pro správu jednoduchého ActiveX ovládacího prvku, jako je textové pole a jednoduché tlačítko příkazu, na snímku:

1. Vytvořte instanci třídy Presentation a načtěte prezentaci, která obsahuje ActiveX ovládací prvky.
2. Získejte odkaz na snímek podle jeho indexu.
3. Přistupte k ActiveX ovládacím prvkům na snímku pomocí IControlCollection.
4. Získejte ActiveX ovládací prvek TextBox1 pomocí objektu ControlEx.
5. Změňte různé vlastnosti ActiveX ovládacího prvku TextBox1, včetně textu, písma, výšky písma a pozice rámečku.
6. Přistupte k druhému ovládacímu prvku pojmenovanému CommandButton1.
7. Změňte popisek tlačítka, písmo a pozici.
8. Posuňte pozici rámců ActiveX ovládacích prvků.
9. Zapište upravenou prezentaci do souboru PPTX.

Ukázkový kód níže aktualizuje ActiveX ovládací prvky na snímcích prezentace podle snímku zobrazeného níže.

```c#
// Přístup k prezentaci s ActiveX ovládacími prvky
Presentation presentation = new Presentation("ActiveX.pptm");

// Přístup k prvnímu snímku v prezentaci
ISlide slide = presentation.Slides[0];

// changing TextBox text
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    //    změna náhradního obrázku. PowerPoint nahradí tento obrázek během aktivace ActiveX, takže je někdy v pořádku nechat obrázek beze změny.

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

//    změna popisku tlačítka
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    //    změna náhrady
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Posunutí rámců ActiveX o 100 bodů dolů
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Uložení prezentace s upravenými ActiveX ovládacími prvky
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Nyní odstraňuji ovládací prvky
slide.Controls.Clear();

// Ukládání prezentace s vyčištěnými ActiveX ovládacími prvky
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```

## **Přidat ActiveX mediální přehrávač**

Chcete-li přidat ActiveX Media Player ovládací prvek, proveďte následující kroky:

1. Vytvořte instanci třídy Presentation a načtěte ukázkovou prezentaci, která obsahuje ActiveX ovládací prvky Media Player.
2. Vytvořte instanci cílové třídy Presentation a vytvořte prázdnou prezentaci.
3. Zkopírujte snímek s ActiveX ovládacím prvkem Media Player ze šablonové prezentace do cílové prezentace.
4. Získejte přístup ke zkopírovanému snímku v cílové prezentaci.
5. Přistupte k ActiveX ovládacím prvkům na snímku pomocí IControlCollection.
6. Získejte ActiveX ovládací prvek Media Player a nastavte cestu k videu pomocí jeho vlastností.
7. Uložte prezentaci do souboru PPTX.

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
Presentation presentation = new Presentation("template.pptx");

// Vytvořte prázdnou instanci prezentace
Presentation newPresentation = new Presentation();

// Odstraňte výchozí snímek
newPresentation.Slides.RemoveAt(0);

// Zkopírujte snímek s Media Player ActiveX ovládacím prvkem
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Přístup k Media Player ActiveX ovládacímu prvku a nastavení cesty k videu
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Uložte prezentaci
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Často kladené otázky**

**Zachovává Aspose.Slides ActiveX ovládací prvky při čtení a opětovném uložení, pokud nemohou být spuštěny v .NET runtime?**

Ano. Aspose.Slides je považuje za součást prezentace a dokáže číst / upravovat jejich vlastnosti a rámečky; k zachování není nutné spouštět samotné ovládací prvky.

**Jak se ActiveX ovládací prvky liší od OLE objektů v prezentaci?**

ActiveX ovládací prvky jsou interaktivní řízené prvky (tlačítka, textová pole, mediální přehrávač), zatímco [OLE](/slides/cs/net/manage-ole/) odkazuje na vložené aplikační objekty (například list Excelu). Jsou ukládány a zpracovávány odlišně a mají jiný model vlastností.

**Fungují události ActiveX a VBA makra, pokud byl soubor upraven pomocí Aspose.Slides?**

Aspose.Slides zachovává stávající značkování a metadata; události a makra však běží pouze v PowerPointu pod Windows, pokud to zabezpečení umožní. Knihovna nespouští VBA.