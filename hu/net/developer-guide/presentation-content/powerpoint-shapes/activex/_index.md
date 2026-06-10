---
title: ActiveX vezérlők kezelése prezentációkban .NET-ben
linktitle: ActiveX
type: docs
weight: 80
url: /hu/net/activex/
keywords:
- ActiveX
- ActiveX vezérlő
- ActiveX kezelése
- ActiveX hozzáadása
- ActiveX módosítása
- médialejátszó
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan használja ki az Aspose.Slides for .NET az ActiveX-et a PowerPoint prezentációk automatizálásához és fejlesztéséhez, erőteljes vezérlést biztosítva a fejlesztőknek a diák felett."
---
## **Bevezetés**

Az ActiveX vezérlőket prezentációkban használják. Az Aspose.Slides for .NET lehetővé teszi az ActiveX vezérlők kezelését, de ezek kezelése valamivel trükkösebb és eltér a szokásos prezentációs alakzatoktól. Az Aspose.Slides for .NET 6.9.0‑tól a komponens támogatja az ActiveX vezérlők kezelését. Jelenleg hozzáférhet a már hozzáadott ActiveX vezérlőhöz a prezentációban, és módosíthatja vagy törölheti azt különböző tulajdonságainak használatával. Ne feledje, az ActiveX vezérlők nem alakzatok, és nem részei a prezentáció IShapeCollection‑ének, hanem a különálló IControlCollection‑nek. Ez a cikk bemutatja, hogyan dolgozzunk velük.

## **ActiveX vezérlők módosítása**
Egy egyszerű ActiveX vezérlő, például egy szövegdoboz és egy egyszerű parancsgomb kezelése egy dián:

1. Hozzon létre egy Presentation példányt, és töltse be a benne lévő ActiveX vezérlőkkel rendelkező prezentációt.
1. Szerezze meg a dia hivatkozását az indexe alapján.
1. A dián lévő ActiveX vezérlőkhöz a IControlCollection elérésével férjen hozzá.
1. A TextBox1 ActiveX vezérlőhöz a ControlEx objektum használatával férjen hozzá.
1. Módosítsa a TextBox1 ActiveX vezérlő különböző tulajdonságait, beleértve a szöveget, betűtípust, betűmagasságot és a keret pozícióját.
1. Szerezze meg a második hozzáférési vezérlőt, amelynek neve CommandButton1.
1. Módosítsa a gomb feliratát, betűtípust és pozíciót.
1. Tolja el az ActiveX vezérlők keretének pozícióját.
1. Írja ki a módosított prezentációt egy PPTX fájlba.

Az alábbi kódrészlet frissíti a prezentáció diáin lévő ActiveX vezérlőket, ahogy az alább látható.

```c#
// A prezentáció elérése ActiveX vezérlőkkel
Presentation presentation = new Presentation("ActiveX.pptm");

// Accessing the first slide in presentation
ISlide slide = presentation.Slides[0];

// szövegmező szövegének módosítása
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // helyettesítő kép módosítása. A PowerPoint ez a képet az ActiveX aktiválásakor cseréli, ezért néha rendben van, ha a képet változatlanul hagyjuk.

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

// gomb feliratának módosítása
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // helyettesítő módosítása
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

// ActiveX keretek 100 ponttal lefelé mozgatása
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// A prezentáció mentése módosított ActiveX vezérlőkkel
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Most a vezérlők eltávolítása
slide.Controls.Clear();

// A prezentáció mentése törölt ActiveX vezérlőkkel
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```

## **ActiveX Media Player vezérlő hozzáadása**
ActiveX Media Player vezérlő hozzáadásához hajtsa végre a következő lépéseket:

1. Hozzon létre egy Presentation példányt, és töltse be a Media Player ActiveX vezérlőkkel rendelkező minta prezentációt.
1. Hozzon létre egy cél Presentation példányt, és generáljon egy üres prezentációt.
1. Klónozza a sablon prezentációban található Media Player ActiveX vezérlővel rendelkező diát a cél Presentation-be.
1. Szerezze meg a klónozott diát a cél Presentation-ben.
1. A dián lévő ActiveX vezérlőkhöz a IControlCollection elérésével férjen hozzá.
1. A Media Player ActiveX vezérlőhöz férjen hozzá, és a tulajdonságainak segítségével állítsa be a videó útvonalát.
1. Mentse a prezentációt egy PPTX fájlba.

```c#
 // PPTX fájlt reprezentáló Presentation osztály példányosítása
 Presentation presentation = new Presentation("template.pptx");

 // Üres prezentáció példányának létrehozása
 Presentation newPresentation = new Presentation();

 // Alapértelmezett dia eltávolítása
 newPresentation.Slides.RemoveAt(0);

 // Dia klónozása Media Player ActiveX vezérlővel
 newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

 // A Media Player ActiveX vezérlő elérése és a videó útvonalának beállítása
 newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

 // A prezentáció mentése
 newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **GYIK**

**Megőrzi-e az Aspose.Slides az ActiveX vezérlőket olvasáskor és újra mentéskor, ha azok nem futtathatók a .NET futtatókörnyezetben?**

Igen. Az Aspose.Slides a vezérlőket a prezentáció részeként kezeli, és képes olvasni/modosítani azok tulajdonságait és kereteit; a vezérlők tényleges végrehajtása nem szükséges a megőrzésükhöz.

**Miben különböznek az ActiveX vezérlők az OLE objektumoktól egy prezentációban?**

Az ActiveX vezérlők interaktív, kezelt vezérlők (gombok, szövegdobozok, médialejátszó), míg az [OLE](/slides/hu/net/manage-ole/) beágyazott alkalmazásobjektumokra (például egy Excel munkalapra) utal. Másként tárolódnak és kezelődnek, valamint eltérő tulajdonságmodelljük van.

**Működnek-e az ActiveX események és a VBA makrók, ha a fájlt az Aspose.Slides módosította?**

Az Aspose.Slides megőrzi a meglévő jelölőket és metaadatokat; azonban az események és makrók csak a Windows-on futó PowerPointban működnek, ha a biztonsági beállítások engedélyezik. A könyvtár nem hajtja végre a VBA‑t.