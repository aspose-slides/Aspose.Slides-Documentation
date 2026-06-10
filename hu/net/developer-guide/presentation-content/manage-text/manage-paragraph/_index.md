---
title: PowerPoint szövegbekezdések kezelése .NET-ben
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/net/manage-paragraph/
keywords:
- szöveg hozzáadása
- bekezdés hozzáadása
- szöveg kezelése
- bekezdés kezelése
- felsorolás kezelése
- bekezdés behúzása
- lógó behúzás
- bekezdés felsorolás
- számozott lista
- felsoroláslista
- bekezdés tulajdonságok
- HTML importálása
- szöveg HTML-be
- bekezdés HTML-be
- bekezdés képpé
- szöveg képpé
- bekezdés exportálása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Mesteri bekezdésformázás az Aspose.Slides .NET számára – optimalizálja a igazítást, távolságot és stílust PPT, PPTX és ODP prezentációkban C#-ban."
---
## **Bevezetés**

Az Aspose.Slides minden szükséges interfészt és osztályt biztosít a PowerPoint szövegek, bekezdések és részek C#-ban történő kezeléséhez.

* Az Aspose.Slides biztosítja az [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) interfészt, amely lehetővé teszi, hogy olyan objektumokat adjunk hozzá, amelyek egy bekezdést képviselnek. Egy `ITextFame` objektumnak lehet egy vagy több bekezdése (minden bekezdés egy sortöréssel jön létre).
* Az Aspose.Slides biztosítja az [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) interfészt, amely lehetővé teszi, hogy olyan objektumokat adjunk hozzá, amelyek részeket képviselnek. Egy `IParagraph` objektumnak lehet egy vagy több részlete (az iPortions objektumok gyűjteménye).
* Az Aspose.Slides biztosítja az [IPortion](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/) interfészt, amely lehetővé teszi, hogy olyan objektumokat adjunk hozzá, amelyek szövegeket és azok formázási tulajdonságait képviselik.

Egy `IParagraph` objektum képes különböző formázási tulajdonságú szövegek kezelésére az alatta lévő `IPortion` objektumok segítségével.

## **Több bekezdés hozzáadása, amelyek több részt tartalmaznak**

Ezek a lépések megmutatják, hogyan adjon hozzá egy szövegkeretet, amely 3 bekezdést és minden bekezdés 3 részt tartalmaz.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Szerezze meg a megfelelő dia referenciaját az indexe alapján.
3. Adjon hozzá egy téglalap [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diára.
4. Szerezze meg az [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemhez társított ITextFrame-et.
5. Hozzon létre két [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) objektumot, és adja hozzá őket a `IParagraphs` gyűjteményhez a [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemben.
6. Minden új `IParagraph` számára hozzon létre három [IPortion](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/) objektumot (az alapértelmezett bekezdéshez két Portion objektumot), és adja hozzá az egyes `IPortion` objektumokat az adott `IParagraph` IPortion gyűjteményéhez.
7. Állítson be szöveget minden részhez.
8. Alkalmazza a kívánt formázási beállításokat minden részre a `IPortion` objektum által biztosított formázási tulajdonságokkal.
9. Mentse el a módosított bemutatót.

Ez a C# kód a bekezdések és részek hozzáadásának lépéseit valósítja meg:

```c#
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation pres = new Presentation())
{
    // Eléri az első diát
    ISlide slide = pres.Slides[0];

    // Hozzáad egy Rectangle IAutoShape elemet
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Eléri az AutoShape TextFrame-jét
    ITextFrame tf = ashp.TextFrame;

    // Létrehozza a bekezdéseket és részeket különböző szövegformátumokkal
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // Elmenti a módosított bemutatót
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```

## **Bekezdés felsoroláskezelés**

A felsorolások segítenek az információ gyors és hatékony rendszerezésében és bemutatásában. A felsorolásos bekezdések mindig könnyebben olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Szerezze meg a megfelelő dia referenciaját az indexe alapján.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a kiválasztott diára.
4. Szerezze meg az autoshape [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) elemét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`-ből.
6. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) osztállyal.
8. Állítsa be a bekezdés bullet `Type` értékét `Symbol`-ra, és adja meg a bullet karaktert.
9. Állítsa be a bekezdés `Text` értékét.
10. Állítsa be a bekezdés `Indent` értékét a bullethez.
11. Állítson be színt a bullethez.
12. Állítson be magasságot a bulletnek.
13. Adja hozzá az új bekezdést a `TextFrame` bekezdésgyűjteményéhez.
14. Adja hozzá a második bekezdést, és ismételje meg a 7‑13. lépésben leírt folyamatot.
15. Mentse el a bemutatót.

```c#
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation pres = new Presentation())
{

    // Eléri az első diát
    ISlide slide = pres.Slides[0];


    // Hozzáad és eléri az Autoshape elemet
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Eléri az autoshape szövegkeretét
    ITextFrame txtFrm = aShp.TextFrame;

    // Eltávolítja az alapértelmezett bekezdést
    txtFrm.Paragraphs.RemoveAt(0);

    // Létrehoz egy bekezdést
    Paragraph para = new Paragraph();

    // Beállítja a bekezdés bullet stílusát és szimbólumát
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Beállítja a bekezdés szövegét
    para.Text = "Welcome to Aspose.Slides";

    // Beállítja a bullet behúzását
    para.ParagraphFormat.Indent = 25;

    // Beállítja a bullet színét
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // állítsa az IsBulletHardColor értékét true-ra, hogy saját bullet színt használjon

    // Beállítja a bullet magasságát
    para.ParagraphFormat.Bullet.Height = 100;

    // Hozzáadja a bekezdést a szövegkerethez
    txtFrm.Paragraphs.Add(para);

    // Létrehoz egy második bekezdést
    Paragraph para2 = new Paragraph();

    // Beállítja a bekezdés bullet típusát és stílusát
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Hozzáadja a bekezdés szövegét
    para2.Text = "This is numbered bullet";

    // Beállítja a bullet behúzását
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // állítsa az IsBulletHardColor értékét true-ra, hogy saját bullet színt használjon

    // Beállítja a bullet magasságát
    para2.ParagraphFormat.Bullet.Height = 100;

    // Hozzáadja a bekezdést a szövegkerethez
    txtFrm.Paragraphs.Add(para2);


    // Elmenti a módosított bemutatót
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Kép felsorolások kezelése**

A felsorolások segítenek az információ gyors és hatékony rendszerezésében és bemutatásában. A képes bekezdések könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Szerezze meg a megfelelő dia referenciaját az indexe alapján.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diára.
4. Szerezze meg az autoshape [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) elemét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`-ből.
6. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) osztállyal.
7. Töltse be a képet a [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) segítségével.
8. Állítsa be a bullet típust [Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) értékre, és adja meg a képet.
9. Állítsa be a Paragraph `Text` értékét.
10. Állítsa be a Paragraph `Indent` értékét a bullethez.
11. Állítson be színt a bullethez.
12. Állítson be magasságot a bulletnek.
13. Adja hozzá az új bekezdést a `TextFrame` bekezdésgyűjteményéhez.
14. Adja hozzá a második bekezdést, és ismételje meg a korábbi lépéseket.
15. Mentse el a módosított bemutatót.

```c#
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation presentation = new Presentation();

// Eléri az első diát
ISlide slide = presentation.Slides[0];

// Példányosítja a bulletokhoz használt képet
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Hozzáad és eléri az Autoshape elemet
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Eléri az autoshape szövegkeretét
ITextFrame textFrame = autoShape.TextFrame;

// Eltávolítja az alapértelmezett bekezdést
textFrame.Paragraphs.RemoveAt(0);

// Létrehoz egy új bekezdést
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Beállítja a bekezdés bullet stílusát és képét
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Beállítja a bullet magasságát
paragraph.ParagraphFormat.Bullet.Height = 100;

// Hozzáadja a bekezdést a szövegkerethez
textFrame.Paragraphs.Add(paragraph);

// Mentés PPTX fájlként
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Mentés PPT fájlként
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Többszintű felsorolások kezelése**

A felsorolások segítenek az információ gyors és hatékony rendszerezésében és bemutatásában. A többszintű felsorolások könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)osztályból.
2. Szerezze meg a megfelelő dia referenciaját az indexe alapján.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet az új diára.
4. Szerezze meg az autoshape [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) elemét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`-ből.
6. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) osztály segítségével, és állítsa be a mélységet 0-ra.
7. Hozza létre a második bekezdést a `Paragraph` osztály segítségével, és állítsa be a mélységet 1-re.
8. Hozza létre a harmadik bekezdést a `Paragraph` osztály segítségével, és állítsa be a mélységet 2-re.
9. Hozza létre a negyedik bekezdést a `Paragraph` osztály segítségével, és állítsa be a mélységet 3-ra.
10. Adja hozzá az új bekezdéseket a `TextFrame` bekezdésgyűjteményéhez.
11. Mentse el a módosított bemutatót.

```c#
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation pres = new Presentation())
{

    // Eléri az első diát
    ISlide slide = pres.Slides[0];
    
    // Hozzáad és eléri az Autoshape elemet
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Eléri a létrehozott autoshape szövegkeretét
    ITextFrame text = aShp.AddTextFrame("");
    
    // Törli az alapértelmezett bekezdést
    text.Paragraphs.Clear();

    // Hozzáadja az első bekezdést
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Beállítja a bullet szintjét
    para1.ParagraphFormat.Depth = 0;

    // Hozzáadja a második bekezdést
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Beállítja a bullet szintjét
    para2.ParagraphFormat.Depth = 1;

    // Hozzáadja a harmadik bekezdést
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Beállítja a bullet szintjét
    para3.ParagraphFormat.Depth = 2;

    // Hozzáadja a negyedik bekezdést
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Beállítja a bullet szintjét
    para4.ParagraphFormat.Depth = 3;

    // Hozzáadja a bekezdéseket a gyűjteményhez
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Mentés PPTX fájlként
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Egy bekezdés kezelése egy egyedi számozott listával**

Az [IBulletFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/) interfész biztosítja a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/numberedbulletstartwith) tulajdonságot és egyéb lehetőségeket, amelyek lehetővé teszik a bekezdések egyedi számozású vagy formázott kezelését.

1. Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)osztályból.
2. Szerezze meg a bekezdést tartalmazó diát.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
4. Szerezze meg az autoshape [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) elemét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`-ből.
6. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) osztály segítségével, és állítsa be a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/numberedbulletstartwith) értékét 2-re.
7. Hozza létre a második bekezdést a `Paragraph` osztály segítségével, és állítsa be a `NumberedBulletStartWith` értékét 3-ra.
8. Hozza létre a harmadik bekezdést a `Paragraph` osztály segítségével, és állítsa be a `NumberedBulletStartWith` értékét 7-re.
9. Adja hozzá az új bekezdéseket a `TextFrame` bekezdésgyűjteményéhez.
10. Mentse el a módosított bemutatót.

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Eléri a létrehozott autoshape szövegkeretét
	ITextFrame textFrame = shape.TextFrame;

	// Eltávolítja az alapértelmezett létező bekezdést
	textFrame.Paragraphs.RemoveAt(0);

	// Első lista
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **Első sor behúzás beállítása bekezdéshez**

Használja az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) tulajdonságot a bekezdés első sorának behúzásának szabályozásához. Ez a tulajdonság csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzshöz igazodik.

Használja az [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginleft/) tulajdonságot, ha a teljes bekezdést szeretné eltolni. Használja az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) tulajdonságot, ha csak az első sort szeretné eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző `Indent` értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
2. Szerezze meg a cél diát.
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/) elemet a diához.
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) elemet a formához, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse el a módosított bemutatót.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A bekezdések első sor behúzása](first_line_indent.png)

## **Lógó behúzás beállítása bekezdéshez**

A lógó behúzás egy olyan bekezdéselrendezés, ahol az első sor a többi sor bal oldalán kezdődik. Az Aspose.Slides-ban ezt a hatást az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) tulajdonsággal hozhatja létre. Állítsa a `Indent` értékét negatívra, hogy az első sor balra mozduljon a bekezdés törzshöz képest.

Gyakorlatban az [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginleft/) határozza meg a bekezdés törzsének bal pozícióját, az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) pedig az első sor pozícióját ehhez a margóhoz képest. Lógó behúzás létrehozásához állítson be egy pozitív `MarginLeft` értéket és egy negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedetek és más bekezdések esetén, ahol a tördelődő soroknak a bekezdés törzsének alá kell illeszkedniük, nem pedig az első sor első karakteréhez.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
2. Szerezze meg a cél diát.
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/) elemet a diához.
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) elemet a formához, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be egy pozitív [MarginLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginleft/) értéket minden bekezdéshez.
6. Állítson be egy negatív [Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) értéket a lógó behúzás hatásának létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse el a módosított bemutatót.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A bekezdések lógó behúzása](hanging_indent.png)

## **Bekezdés végének futás tulajdonságainak kezelése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Szerezze meg a bekezdést tartalmazó dia referenciáját a pozíciója alapján.
3. Adjon hozzá egy téglalap [autoshape](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/) elemet a diához.
4. Adjon egy [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) elemet két bekezdéssel a téglalaphoz.
5. Állítsa be a bekezdések `FontHeight` és betűtípus értékét.
6. Állítsa be a bekezdések End tulajdonságait.
7. Írja ki a módosított bemutatót PPTX fájlként.

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **HTML szöveg importálása bekezdésekbe**

Az Aspose.Slides fejlett támogatást nyújt a HTML szöveg bekezdésekbe történő importálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Szerezze meg a megfelelő dia referenciaját az indexe alapján.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/) elemet a diára.
4. Adjon hozzá és érje el az `autoshape` [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) elemét.
5. Távolítsa el az alapértelmezett bekezdést az `ITextFrame`-ből.
6. Olvassa be a forrás HTML fájlt egy TextReader segítségével.
7. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) osztály segítségével.
8. Adja hozzá a beolvasott TextReader HTML tartalmát a TextFrame [ParagraphCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphcollection/) gyűjteményéhez.
9. Mentse el a módosított bemutatót.

```c#
// Létrehozza az üres bemutató példányát
using (Presentation pres = new Presentation())
{
    // Eléri a bemutató alapértelmezett első diáját
    ISlide slide = pres.Slides[0];

    // Hozzáadja az AutoShape elemet, amely a HTML tartalmat tartalmazza
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Hozzáad egy szövegkeretet a formához
    ashape.AddTextFrame("");

    // Törli az összes bekezdést a hozzáadott szövegkeretben
    ashape.TextFrame.Paragraphs.Clear();

    // Betölti a HTML fájlt stream olvasóval
    TextReader tr = new StreamReader("file.html");

    // A HTML stream olvasóból származó szöveget hozzáadja a szövegkerethez
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Elmenti a bemutatót
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Bekezdés szöveg exportálása HTML-be**

Az Aspose.Slides fejlett támogatást nyújt a szövegek (bekezdésekben) HTML-be exportálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, és töltse be a kívánt bemutatót.
2. Szerezze meg a megfelelő dia referenciaját az indexe alapján.
3. Szerezze meg a szöveget tartalmazó alakzatot, amelyet HTML-be exportálni kíván.
4. Érje el a alakzat [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) elemét.
5. Hozzon létre egy `StreamWriter` példányt, és adja hozzá az új HTML fájlt.
6. Adjon meg egy kezdő indexet a StreamWriternek, és exportálja a kívánt bekezdéseket.

```c#
// Betölti a bemutató fájlt
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Eléri a bemutató alapértelmezett első diáját
    ISlide slide = pres.Slides[0];

    // Eléri a szükséges indexet
    int index = 0;

    // Eléri a hozzáadott alakzatot
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Bekezdések adatait HTML-be írja, megadva a kezdő bekezdésindexet és a másolandó bekezdések számát
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Bekezdés mentése képként**

Az ebben a szakaszban két példát mutatunk be, amelyek bemutatják, hogyan menthetünk egy szövegbekezdést, amelyet az [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) interfész képvisel, képként. Mindkét példa magában foglalja a bekezdést tartalmazó alakzat képének megszerzését a [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) interfész `GetImage` metódusaival, a bekezdés határainak kiszámítását az alakzaton belül, valamint annak bitmap képként való exportálását. Ezek a megközelítések lehetővé teszik a PowerPoint prezentációkból származó szövegrészek kinyerését és különálló képként történő mentését, ami különféle forgatókönyvekben hasznos lehet.

Tegyük fel, hogy van egy sample.pptx nevű bemutató fájlnk egy diával, ahol az első alakzat egy szövegdoboz, amely három bekezdést tartalmaz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

**Example 1**

Ebben a példában a második bekezdést jelenítjük meg képként. Ehhez kinyerjük a forma képét a bemutató első diájáról, majd kiszámítjuk a második bekezdés határait a forma szövegkeretében. A bekezdést ezután új bitmap képre rajzoljuk át, amelyet PNG formátumban mentünk. Ez a módszer különösen hasznos, ha egy adott bekezdést külön képként szeretnénk menteni anélkül, hogy a szöveg pontos méreteit és formázását megváltoztatnánk.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Mentse el a formát memóriában bitmapként.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Hozzon létre egy alakzat bitmapet a memóriából.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Számolja ki a második bekezdés határait.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Számolja ki a kimeneti kép méretét (minimum méret - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Készítsen bitmapet a bekezdéshez.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Rajzolja újra a bekezdést az alakzat bitmapből a bekezdés bitmapre.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

Az eredmény:

![A bekezdés képe](paragraph_to_image_output.png)

**Example 2**

Ebben a példában a korábbi megközelítést bővítjük a bekezdés képéhez skálázási tényezők hozzáadásával. A forma kinyerésre kerül a bemutatóból, és `2`‑es skálázási tényezővel képként mentődik. Ez lehetővé teszi a bekezdés exportálásakor a magasabb felbontású kimenetet. A bekezdés határait ezután a skálát figyelembe véve számítjuk ki. A skálázás különösen hasznos, ha részletesebb képre van szükség, például magas minőségű nyomtatott anyagokhoz.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// A formát memóriában bitmapként, skálázással menti.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Létrehozza a forma bitmapet a memóriából.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Kiszámítja a második bekezdés határait.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Kiszámítja a kimeneti kép méretét (minimum méret - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Előkészíti a bitmapet a bekezdéshez.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Újrarajzolja a bekezdést a forma bitmapből a bekezdés bitmapre.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **GYIK**

**Lehet-e teljesen letiltani a sortörést egy szövegkereten belül?**

Igen. Használja a szövegkeret sortörés beállítását ([WrapText](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat/wraptext/)), hogy letiltsa a sortörést, így a sorok nem törnek meg a keret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos helyét a dián?**

Lekérheti a bekezdés (vagy akár egyetlen rész) határoló téglalapját, hogy tudja a pontos pozícióját és méretét a dián.

**Hol szabályozható a bekezdés igazítása (balra/jobbra/középre/széthúzott)?**

Az [Alignment](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphformat/alignment/) a bekezdés szintű beállítás a [ParagraphFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphformat/)‑ban; a teljes bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

**Beállíthatok helyesírás-nyelvet a bekezdés egy részére (például egy szóra)?**

Igen. A nyelv a rész szintjén van beállítva ([PortionFormat.LanguageId](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/languageid/)), így több nyelv is együtt létezhet egy bekezdésen belül.