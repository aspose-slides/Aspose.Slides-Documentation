---
title: PowerPoint szövegbekezdések kezelése .NET-ben
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- szöveg hozzáadása
- bekezdés hozzáadása
- szöveg kezelése
- bekezdés kezelése
- felsorolás kezelése
- bekezdés behúzás
- függő behúzás
- bekezdés felsorolás
- számozott lista
- felsorolás lista
- bekezdés tulajdonságok
- HTML importálás
- szöveg HTML-re
- bekezdés HTML-re
- bekezdés képre
- szöveg képre
- bekezdés exportálása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Mesteri bekezdés formázás az Aspose.Slides for .NET‑tel — optimalizálja a igazítást, távolságot és stílust PPT, PPTX és ODP prezentációkban C#‑ban."
---
## **Bevezetés**

Az Aspose.Slides minden szükséges interfészt és osztályt biztosít a PowerPoint szövegek, bekezdések és részek C#-ban történő kezeléséhez.

* Az Aspose.Slides biztosítja a [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) interfészt, amely lehetővé teszi olyan objektumok hozzáadását, amelyek egy bekezdést képviselnek. Egy `ITextFame` objektumnak egy vagy több bekezdése lehet (minden bekezdés egy sortöréssel jön létre).
* Az Aspose.Slides biztosítja a [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) interfészt, amely lehetővé teszi olyan objektumok hozzáadását, amelyek részeket képviselnek. Egy `IParagraph` objektumnak egy vagy több részlete (iPortions objektumok gyűjteménye) lehet.
* Az Aspose.Slides biztosítja a [IPortion](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/) interfészt, amely lehetővé teszi olyan objektumok hozzáadását, amelyek szöveget és annak formázási tulajdonságait képviselik.

Egy `IParagraph` objektum képes kezelni a különböző formázási tulajdonságokkal rendelkező szövegeket az alatta lévő `IPortion` objektumok segítségével.

## **Több bekezdés hozzáadása több részzel**

Ez a lépéssor megmutatja, hogyan adjon hozzá egy szövegdobozt, amely 3 bekezdést tartalmaz, és minden bekezdés 3 részt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Hozza el a megfelelő dia referenciáját az indexe alapján.
3. Adjon egy téglalap [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) alakzatot a diára.
4. Szerezze meg az [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) alakzathoz tartozó ITextFrame-et.
5. Hozzon létre két [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) objektumot, és adja őket az [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) `IParagraphs` gyűjteményéhez.
6. Hozzon létre három [IPortion](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/) objektumot minden új `IParagraph`-hez (alapértelmezett bekezdéshez két Portion objektum), majd adja hozzá az egyes `IPortion` objektumokat az adott `IParagraph` IPortion gyűjteményéhez.
7. Állítson be szöveget minden részhez.
8. Alkalmazza a kívánt formázási funkciókat minden részre a `IPortion` objektum által biztosított formázási tulajdonságok segítségével.
9. Mentse a módosított prezentációt.

```c#
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation pres = new Presentation())
{
    // Eléri az első diát
    ISlide slide = pres.Slides[0];

    // Hozzáad egy téglalap IAutoShape‑t
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Eléri az AutoShape TextFrame‑et
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
    // Mentse a módosított prezentációt
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);

}
```

## **Bekezdés felsoroláspontok kezelése**

A felsoroláslista segít gyorsan és hatékonyan rendszerezni és bemutatni az információkat. A felsoroláspontokkal ellátott bekezdések mindig könnyebben olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Hozza el a megfelelő dia referenciáját az indexe alapján.
3. Adjon egy [autoshape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) alakzatot a kiválasztott diára.
4. Szerezze meg az autoshape [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) elemét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`-ből.
6. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) osztállyal.
8. Állítsa be a bekezdés bullet `Type`-ját `Symbol`-ra, és adja meg a bullet karaktert.
9. Állítsa be a bekezdés `Text`-ét.
10. Állítsa be a bekezdés bullet `Indent`-ját.
11. Állítson be színt a bullet-nek.
12. Állítson be magasságot a bullet-nek.
13. Adja hozzá az új bekezdést a `TextFrame` bekezdésgyűjteményéhez.
14. Adjon hozzá egy második bekezdést, és ismételje meg a 7‑13. lépésekben leírt folyamatot.
15. Mentse a prezentációt.

```c#
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation pres = new Presentation())
{

    // Eléri az első diát
    ISlide slide = pres.Slides[0];


    // Hozzáad és eléri az Autoshape‑t
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Eléri az autoshape szövegdobozát
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

    // Beállítja a bullet behúzást
    para.ParagraphFormat.Indent = 25;

    // Beállítja a bullet színét
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // állítsa az IsBulletHardColor értékét true‑ra, hogy saját bullet színt használjon

    // Beállítja a bullet magasságát
    para.ParagraphFormat.Bullet.Height = 100;

    // Hozzáadja a bekezdést a szövegdobozhoz
    txtFrm.Paragraphs.Add(para);

    // Létrehoz egy második bekezdést
    Paragraph para2 = new Paragraph();

    // Beállítja a bekezdés bullet típusát és stílusát
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Hozzáadja a bekezdés szövegét
    para2.Text = "This is numbered bullet";

    // Beállítja a bullet behúzást
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // állítsa az IsBulletHardColor értékét true‑ra, hogy saját bullet színt használjon

    // Beállítja a bullet magasságát
    para2.ParagraphFormat.Bullet.Height = 100;

    // Hozzáadja a bekezdést a szövegdobozhoz
    txtFrm.Paragraphs.Add(para2);


    // Mentse a módosított prezentációt
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Képes felsoroláspontok kezelése**

A felsoroláslisták segítenek gyorsan és hatékonyan rendszerezni és bemutatni az információkat. Képes bekezdések könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Hozza el a megfelelő dia referenciáját az indexe alapján.
3. Adjon egy [autoshape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) alakzatot a diára.
4. Szerezze meg az autoshape [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) elemét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`-ből.
6. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) osztállyal.
7. Töltse be a képet az [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) segítségével.
8. Állítsa be a bullet típusát [Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) értékre, és adja meg a képet.
9. Állítsa be a Paragraph `Text`-et.
10. Állítsa be a Paragraph bullet `Indent`-ját.
11. Állítson be színt a bullet-nek.
12. Állítson be magasságot a bullet-nek.
13. Adja hozzá az új bekezdést a `TextFrame` bekezdésgyűjteményéhez.
14. Adjon hozzá egy második bekezdést, és ismételje meg a korábban leírt lépéseket.
15. Mentse a módosított prezentációt.

```c#
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation presentation = new Presentation();

// Eléri az első diát
ISlide slide = presentation.Slides[0];

// Létrehozza a bulletokhoz használt képet
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Hozzáadja és eléri az Autoshape‑t
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Eléri az autoshape szövegdobozát
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

// Hozzáadja a bekezdést a szövegdobozhoz
textFrame.Paragraphs.Add(paragraph);

// Kiírja a prezentációt PPTX fájlként
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Kiírja a prezentációt PPT fájlként
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Többszintű felsoroláspontok kezelése**

A felsoroláslisták segítenek gyorsan és hatékonyan rendszerezni és bemutatni az információkat. A több szintű felsoroláspontok könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Hozza el a megfelelő dia referenciáját az indexe alapján.
3. Adjon egy [autoshape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) alakzatot az új diára.
4. Szerezze meg az autoshape [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) elemét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`-ből.
6. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) osztály segítségével, és állítsa be a mélységet 0-ra.
7. Hozza létre a második bekezdést a `Paragraph` osztály segítségével, és állítsa be a mélységet 1-re.
8. Hozza létre a harmadik bekezdést a `Paragraph` osztály segítségével, és állítsa be a mélységet 2-re.
9. Hozza létre a negyedik bekezdést a `Paragraph` osztály segítségével, és állítsa be a mélységet 3-ra.
10. Adja hozzá az új bekezdéseket a `TextFrame` bekezdésgyűjteményéhez.
11. Mentse a módosított prezentációt.

```c#
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation pres = new Presentation())
{

    // Eléri az első diát
    ISlide slide = pres.Slides[0];
    
    // Hozzáad és eléri az Autoshape‑t
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Eléri a létrehozott autoshape szövegdobozát
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

    // Kiírja a prezentációt PPTX fájlként
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Bekezdés kezelése egy egyéni számozott listával**

Az [IBulletFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/) interfész biztosítja a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/numberedbulletstartwith) tulajdonságot és másokat, amelyek lehetővé teszik a bekezdések saját számozásának vagy formázásának kezelését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Szerezze meg a bekezdést tartalmazó diát.
3. Adjon egy [autoshape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) alakzatot a diára.
4. Szerezze meg az autoshape [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) elemét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`-ből.
6. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) osztállyal, és állítsa a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/numberedbulletstartwith) értékét 2-re.
7. Hozza létre a második bekezdést a `Paragraph` osztállyal, és állítsa a `NumberedBulletStartWith` értékét 3-ra.
8. Hozza létre a harmadik bekezdést a `Paragraph` osztállyal, és állítsa a `NumberedBulletStartWith` értékét 7-re.
9. Adja hozzá az új bekezdéseket a `TextFrame` bekezdésgyűjteményéhez.
10. Mentse a módosított prezentációt.

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Eléri a létrehozott autoshape szövegdobozát
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

Használja az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) tulajdonságot a bekezdés első sorának behúzásának szabályozásához. Ez a tulajdonság csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja az [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginleft/) tulajdonságot, ha az egész bekezdést szeretné eltolni. Használja az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) tulajdonságot, ha csak az első sort akarja eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző `Indent` értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt.
2. Szerezze meg a cél diát.
3. Adjon egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/) alakzatot a diára.
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) elemet az alakzathoz, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) értékeket.
6. Adja hozzá a bekezdéseket a szövegdobozhoz.
7. Mentse a módosított prezentációt.

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

![A bekezdések első sorának behúzása](first_line_indent.png)

## **Függő behúzás beállítása bekezdéshez**

A függő behúzás egy olyan bekezdéselrendezés, amelyben az első sor balra indul a többi sorhoz képest. Az Aspose.Slides-ben ezt a hatást az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) tulajdonsággal hozhatja létre. Állítsa az `Indent` értékét negatívra, hogy az első sor balra mozduljon a bekezdés törzséhez képest.

Gyakorlatban az [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginleft/) meghatározza a bekezdés törzsének bal pozícióját, míg az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) definiálja az első sor pozícióját ehhez a margóhoz képest. Egy függő behúzás létrehozásához állítson be pozitív `MarginLeft` értéket és negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedeti bejegyzések és más bekezdések esetén, ahol a sortöréseknek a bekezdés törzse alá kell igazodniuk, nem pedig az első sor első karakteréhez.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt.
2. Szerezze meg a cél diát.
3. Adjon egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/) alakzatot a diára.
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) elemet az alakzathoz, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be pozitív [MarginLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginleft/) értéket minden bekezdéshez.
6. Állítson be negatív [Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) értéket a függő behúzás hatásának létrehozásához.
7. Adja hozzá a bekezdéseket a szövegdobozhoz.
8. Mentse a módosított prezentációt.

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

![A bekezdések függő behúzása](hanging_indent.png)

## **Bekezdés végi futási tulajdonságainak kezelése**

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból egy példányt.
2. Szerezze meg a bekezdést tartalmazó dia referenciáját a pozíciója alapján.
3. Adjon egy téglalap [autoshape](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/) alakzatot a diára.
4. Adjon egy [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) elemet két bekezdéssel a téglalaphoz.
5. Állítsa be a `FontHeight` és a betűtípus értékeket a bekezdésekhez.
6. Állítsa be a bekezdések End tulajdonságait.
7. Mentse a módosított prezentációt PPTX fájlként.

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

Az Aspose.Slides kibővített támogatást nyújt a HTML szöveg bekezdésekbe történő importálásához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) példányt.
2. Hozza el a megfelelő dia referenciáját az indexe alapján.
3. Adjon egy [autoshape](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/) alakzatot a diára.
4. Adjon hozzá és szerezze meg az `autoshape` [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/).
5. Távolítsa el az alapértelmezett bekezdést a `ITextFrame`-ből.
6. Olvassa be a forrás HTML fájlt egy TextReader segítségével.
7. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) osztály segítségével.
8. Adja hozzá a beolvasott TextReaderből származó HTML fájl tartalmát a TextFrame [ParagraphCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphcollection/) gyűjteményéhez.
9. Mentse a módosított prezentációt.

```c#
// Létrehozza az üres prezentáció példányt
using (Presentation pres = new Presentation())
{
    // Eléri a prezentáció alapértelmezett első diáját
    ISlide slide = pres.Slides[0];

    // Hozzáadja az AutoShape‑t, amely a HTML tartalmat fogja tartalmazni
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Hozzáad egy szövegdobozt az alakzathoz
    ashape.AddTextFrame("");

    // Törli az összes bekezdést a hozzáadott szövegdobozban
    ashape.TextFrame.Paragraphs.Clear();

    // Betölti a HTML fájlt stream olvasóval
    TextReader tr = new StreamReader("file.html");

    // Hozzáadja a HTML stream olvasóból származó szöveget a szövegdobozhoz
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Mentse a prezentációt
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Bekezdés szöveg exportálása HTML-be**

Az Aspose.Slides kibővített támogatást nyújt a szövegek (bekezdésekben szereplő) HTML-be exportálásához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) példányt, és töltse be a kívánt prezentációt.
2. Hozza el a megfelelő dia referenciáját az indexe alapján.
3. Szerezze meg a szöveget tartalmazó alakzatot, amelyet HTML-be exportálni kíván.
4. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) elemét.
5. Hozzon létre egy `StreamWriter` példányt, és adja hozzá az új HTML fájlt.
6. Adjon meg egy kezdő indexet a StreamWriternek, és exportálja a kívánt bekezdéseket.

```c#
// Betölti a prezentáció fájlt
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Eléri a prezentáció alapértelmezett első diáját
    ISlide slide = pres.Slides[0];

    // Eléri a szükséges indexet
    int index = 0;

    // Eléri a hozzáadott alakzatot
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Beküldi a bekezdésadatokat HTML-be a bekezdés kezdő indexének és a másolandó bekezdések számának megadásával
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Bekezdés mentése képként**

Ebben a részben két példát mutatunk be, amelyek bemutatják, hogyan menthetünk egy szöveges bekezdést, amelyet az [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) interfész képvisel, képként. Mindkét példában egy olyan alakzat képét szerezzük be, amely tartalmazza a bekezdést, a `GetImage` metódusokkal az [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) interfészből, kiszámítjuk a bekezdés alakzaton belüli határait, majd bitmap képként exportáljuk. Ezek a megközelítések lehetővé teszik, hogy a PowerPoint prezentációkból specifikus szövegrészeket külön képként nyerjünk ki, ami különféle forgatókönyvekben hasznos lehet.

Tegyük fel, hogy van egy sample.pptx nevű prezentációs fájlunk egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

**Example 1**

Ebben a példában a második bekezdést képként nyerjük ki. Ehhez a prezentáció első diáján lévő alakzat képét nyerjük ki, majd kiszámítjuk a második bekezdés határait az alakzat szövegdobozában. A bekezdést egy új bitmap képre rajzoljuk, amelyet PNG formátumban mentünk. Ez a módszer különösen akkor hasznos, ha egy adott bekezdést szeretnénk külön képként menteni, miközben megőriznénk a szöveg pontos méretét és formázását.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

Az eredmény:

![A bekezdés képe](paragraph_to_image_output.png)

**Example 2**

Ebben a példában a korábbi megközelítést kibővítjük, hogy a bekezdés képre méretezési tényezőket alkalmazzunk. Az alakzatot a prezentációból kinyerjük, és a `GetImage` metódussal 2-es méretezési tényezővel mentjük le. Így nagyobb felbontású kimenetet kapunk a bekezdés exportálásakor. Ezután a bekezdés határait a méretezési tényező figyelembevételével számoljuk ki. A méretezés különösen hasznos, ha részletesebb képre van szükség, például magas minőségű nyomtatott anyagokhoz.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Mentse az alakzatot memóriában méretezett bitmapként.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Hozzon létre egy alakzat bitmapet a memóriából.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Számolja ki a második bekezdés határait.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Számolja ki a kimeneti kép méretét (minimum méret - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Készítsen egy bitmapet a bekezdéshez.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Újrarajzolja a bekezdést az alakzat bitmapről a bekezdés bitmapre.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **GYIK**

**Teljesen le tudom tiltani a sortörést egy szövegdobozon belül?**

Igen. Használja a szövegdoboz **WrapText** ([WrapText](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat/wraptext/)) beállítását a sortörés letiltásához, így a sorok nem törnek meg a doboz szélén.

**Hogyan szerezhetem meg egy adott bekezdés pontos helyét a dián?**

Lekérheti a bekezdés (sőt egyetlen részlet) körülhatároló téglalapját, hogy megtudja a pontos pozícióját és méretét a dián.

**Hol van szabályozva a bekezdés igazítása (bal/jobbra/középre/széthúzott)?**

Az [Alignment](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphformat/alignment/) egy bekezdés-szintű beállítás a [ParagraphFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphformat/)‑ban; a teljes bekezdésre érvényes, függetlenül az egyes részek formázásától.

**Be tudok-e állítani helyesírás-ellenőrzési nyelvet csak a bekezdés egy részére (pl. egy szó)?**

Igen. A nyelv a részre van beállítva ([PortionFormat.LanguageId](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/languageid/)), így egy bekezdésen belül több nyelv is létezhet.