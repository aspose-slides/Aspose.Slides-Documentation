---
title: Hantera ActiveX-kontroller i presentationer i .NET
linktitle: ActiveX
type: docs
weight: 80
url: /sv/net/activex/
keywords:
- ActiveX
- ActiveX-kontroll
- hantera ActiveX
- lägga till ActiveX
- ändra ActiveX
- mediaspelare
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur Aspose.Slides för .NET utnyttjar ActiveX för att automatisera och förbättra PowerPoint-presentationer, vilket ger utvecklare kraftfull kontroll över bildspel."
---
## **Introduktion**

ActiveX-kontroller används i presentationer. Aspose.Slides för .NET låter dig hantera ActiveX-kontroller, men hanteringen är lite knepigare och annorlunda än vanliga presentationsformer. Från Aspose.Slides för .NET 6.9.0 stödjer komponenten hantering av ActiveX-kontroller. För närvarande kan du komma åt redan tillagda ActiveX-kontroller i din presentation och ändra eller ta bort dem genom att använda deras olika egenskaper. Kom ihåg att ActiveX-kontroller inte är former och ingår inte i presentationens IShapeCollection utan i den separata IControlCollection. Den här artikeln visar hur du arbetar med dem.

## **Redigera ActiveX-kontroller**

För att hantera en enkel ActiveX-kontroll som en textruta och en enkel kommandoknapp på en bild:

1. Skapa en instans av Presentation-klassen och läs in presentationen som innehåller ActiveX-kontroller.
1. Hämta en bildreferens med hjälp av dess index.
1. Kom åt ActiveX-kontrollerna i bilden genom att nå IControlCollection.
1. Få åtkomst till ActiveX-kontrollen TextBox1 med ControlEx-objektet.
1. Ändra de olika egenskaperna för TextBox1 ActiveX-kontrollen inklusive text, teckensnitt, teckensnittshöjd och ramposition.
1. Få åtkomst till den andra åtkomstkontrollen som heter CommandButton1.
1. Ändra knappens rubrik, teckensnitt och position.
1. Flytta positionen för ActiveX-kontrollerna ramar.
1. Skriv den modifierade presentationen till en PPTX-fil.

Kodsnutten nedan uppdaterar ActiveX-kontrollerna på presentationsbilderna enligt bilden nedan.

```c#
// Åtkomst till presentationen med  ActiveX-kontroller
Presentation presentation = new Presentation("ActiveX.pptm");

// Åtkomst till den första bilden i presentationen
ISlide slide = presentation.Slides[0];

// ändra TextBox‑text
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // ändrar ersättningsbild. PowerPoint kommer att ersätta denna bild under ActiveX‑aktivering, så ibland är det OK att låta bilden vara oförändrad.

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

// ändra knapptext
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // ändrar ersättning
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

// Flyttar ActiveX‑ramar 100 punkter nedåt
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Spara presentationen med redigerade ActiveX‑kontroller
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Nu tar vi bort kontroller
slide.Controls.Clear();

// Sparar presentationen med rensade ActiveX‑kontroller
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```

## **Lägg till en ActiveX Media Player-kontroll**

För att lägga till en ActiveX Media Player-kontroll, utför följande steg:

1. Skapa en instans av Presentation-klassen och läs in exempelpresentationen som innehåller Media Player ActiveX-kontroller.
1. Skapa en instans av mål‑Presentation‑klassen och generera en tom presentationsinstans.
1. Klona bilden med Media Player ActiveX-kontrollen från mallpresentationen till mål‑Presentation.
1. Få åtkomst till den klonade bilden i mål‑Presentation.
1. Kom åt ActiveX-kontrollerna i bilden genom att nå IControlCollection.
1. Få åtkomst till Media Player ActiveX-kontrollen och ange videons sökväg genom att använda dess egenskaper.
1. Spara presentationen till en PPTX-fil.

```c#
// Instansiera Presentation‑klassen som representerar PPTX‑filen
Presentation presentation = new Presentation("template.pptx");

// Skapa en tom presentationsinstans
Presentation newPresentation = new Presentation();

// Ta bort standardbilden
newPresentation.Slides.RemoveAt(0);

// Klona bilden med Media Player ActiveX‑kontroll
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Åtkom Media Player ActiveX‑kontrollen och ange videons sökväg
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Spara presentationen
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Vanliga frågor**

**Behåller Aspose.Slides ActiveX-kontroller när de läses in och sparas om de inte kan köras i .NET‑runtime?**

Ja. Aspose.Slides behandlar dem som en del av presentationen och kan läsa/ändra deras egenskaper och ramar; att köra själva kontrollerna är inte nödvändigt för att bevara dem.

**Hur skiljer sig ActiveX‑kontroller från OLE-objekt i en presentation?**

ActiveX‑kontroller är interaktiva hanterade kontroller (knappar, textrutor, mediaspelare), medan [OLE](/slides/sv/net/manage-ole/) avser inbäddade programobjekt (till exempel ett Excel‑ kalkylblad). De lagras och hanteras på olika sätt och har olika egenskapsmodeller.

**Fungerar ActiveX‑händelser och VBA‑makron om filen har ändrats av Aspose.Slides?**

Aspose.Slides bevarar den befintliga markup‑ och metadata‑informationen; dock körs händelser och makron endast i PowerPoint på Windows när säkerheten tillåter det. Biblioteket kör inte VBA.