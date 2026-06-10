---
title: Szövegdobozok kezelése a prezentációkban C++‑ segítségével
linktitle: Szövegdoboz kezelése
type: docs
weight: 20
url: /hu/cpp/manage-textbox/
keywords:
- szövegdoboz
- szövegkeret
- szöveg hozzáadása
- szöveg frissítése
- szövegdoboz létrehozása
- szövegdoboz ellenőrzése
- szövegoszlop hozzáadása
- hiperhivatkozás hozzáadása
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Az Aspose.Slides for C++ megkönnyíti a szövegdobozok létrehozását, szerkesztését és klónozását PowerPoint és OpenDocument fájlokban, ezáltal fokozza a prezentációs automatizálást."
---
## **Bevezetés**

A diákat tipikusan szövegdobozok vagy alakzatok tartalmazzák a szöveget. Ezért a szöveg hozzáadásához egy diára először szövegdobozt kell hozzáadni, majd szöveget kell elhelyezni a szövegdobozban. Az Aspose.Slides for C++ biztosítja az [IAutoShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_auto_shape) felületet, amely lehetővé teszi szöveget tartalmazó alakzat hozzáadását.

{{% alert title="Info" color="info" %}}
Az Aspose.Slides emellett a [IShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_shape) felületet is biztosítja, amely lehetővé teszi alakzatok hozzáadását a diákhoz. Azonban nem minden, az `IShape` felületen keresztül hozzáadott alakzat tartalmazhat szöveget. De a [IAutoShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_auto_shape) felületen keresztül hozzáadott alakzatok szöveget tartalmazhatnak.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Ezért amikor egy olyan alakzattal dolgozunk, amelyhez szöveget szeretnénk hozzáadni, érdemes ellenőrizni és megerősíteni, hogy az `IAutoShape` felületen keresztül lett átkonvertálva. Csak ekkor tudunk a [TextFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.text_frame)‑vel dolgozni, amely az `IAutoShape` tulajdonsága. Lásd az [Update Text](https://docs.aspose.com/slides/hu/cpp/manage-textbox/#update-text) szakaszt ezen az oldalon.
{{% /alert %}}

## **Szövegdoboz létrehozása egy dián**

A szövegdoboz létrehozásához egy dián kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Szerezzen egy hivatkozást az újonnan létrehozott prezentáció első diájához.  
3. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_auto_shape) objektumot, amelynek a [ShapeType](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) értéke `Rectangle`, és helyezze el a dián a megadott pozícióban, majd szerezze meg az újonnan hozzáadott `IAutoShape` objektum hivatkozását.  
4. Adj hozzá egy `TextFrame` tulajdonságot az `IAutoShape` objektumhoz, amely szöveget tartalmaz. Az alábbi példában ezt a szöveget adtuk hozzá: *Aspose TextBox*  
5. Végül írja ki a PPTX fájlt a `Presentation` objektumon keresztül.  

Ez a C++ kód – a fenti lépések megvalósítása – megmutatja, hogyan adhat szöveget egy diához:

```cpp
// Létrehozza a Presentation példányt
// Lekéri a prezentáció első diáját
// Hozzáad egy AutoShape-t, amelynek típusa Rectangle
// Hozzáad egy TextFrame-et a Rectangle-hez
// Eléri a szövegkeretet
// Létrehozza a Paragraph objektumot a szövegkerethez
// Létrehozza a Portion objektumot a bekezdéshez
// Beállítja a szöveget
// Mentés a prezentációt a lemezen
auto pres = System::MakeObject<Presentation>();

auto sld = pres->get_Slides()->idx_get(0);

auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

ashp->AddTextFrame(u" ");

auto txtFrame = ashp->get_TextFrame();

auto para = txtFrame->get_Paragraphs()->idx_get(0);

auto portion = para->get_Portions()->idx_get(0);

portion->set_Text(u"Aspose TextBox");

pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Szövegdoboz-alakzat ellenőrzése**

Az Aspose.Slides biztosítja a [get_IsTextBox](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/get_istextbox/) metódust a [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) felületről, amely lehetővé teszi az alakzatok vizsgálatát és a szövegdobozok azonosítását.

![Text box and shape](istextbox.png)

Ez a C++ kód megmutatja, hogyan ellenőrizze, hogy egy alakzat szövegdobozként lett‑e létrehozva:

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

Vegye figyelembe, hogy ha egyszerűen egy autoshape‑et ad hozzá az `AddAutoShape` metódussal a [IShapeCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/) felületről, az autoshape `get_IsTextBox` metódusa `false`‑t fog visszaadni. Azonban miután szöveget ad hozzá az autoshape‑hez az `AddTextFrame` vagy a `set_Text` metódussal, a `get_IsTextBox` metódus `true`‑t ad vissza.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() false értéket ad vissza
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() true értéket ad vissza

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() false értéket ad vissza
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() true értéket ad vissza

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() false értéket ad vissza
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() false értéket ad vissza

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() false értéket ad vissza
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() false értéket ad vissza
```

## **Oszlopok hozzáadása szövegdobozhoz**

Az Aspose.Slides biztosítja a [set_ColumnCount](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) és a [set_ColumnSpacing](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) metódusokat (az [ITextFrameFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_text_frame_format) felületről és a [TextFrameFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_text_frame_format) osztályból), amelyek lehetővé teszik oszlopok hozzáadását a szövegdobozokhoz. Megadhatja a szövegdoboz oszlopainak számát, valamint a pontokban kifejezett távolságot az oszlopok között.

```cpp
auto presentation = System::MakeObject<Presentation>();
// Lekéri a prezentáció első diáját
auto slide = presentation->get_Slides()->idx_get(0);

// Hozzáad egy AutoShape‑t, amelynek típusa Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Hozzáad egy TextFrame‑et a Rectangle-hez
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Lekéri a TextFrame szövegformátumát
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Megadja a oszlopok számát a TextFrame‑ben
format->set_ColumnCount(3);

// Megadja az oszlopok közti távolságot
format->set_ColumnSpacing(10);

// Elmenti a prezentációt
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Oszlopok hozzáadása szövegkerethez**

Az Aspose.Slides for C++ biztosítja a [set_ColumnCount](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) metódust (az [ITextFrameFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_text_frame_format) felületről), amely lehetővé teszi oszlopok hozzáadását a szövegkeretekben. Ezzel a metódussal megadhatja a kívánt oszlopszámot egy szövegkeretben.

```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Szöveg frissítése**

Az Aspose.Slides lehetővé teszi a szövegdobozban vagy a teljes prezentációban szereplő szövegek módosítását vagy frissítését.

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
                {
                    //Szöveget módosít
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Formázást módosít
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Mentés a módosított prezentáció
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Szövegdoboz hozzáadása hiperhivatkozással** 

Hiperhivatkozást szúrhat be egy szövegdobozba. Ha a szövegdobozra kattintanak, a felhasználó a hivatkozásra lesz irányítva.

Egy hivatkozást tartalmazó szövegdoboz hozzáadásához kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a `Presentation` osztályból.  
2. Szerezzen egy hivatkozást az újonnan létrehozott prezentáció első diájához.  
3. Adj hozzá egy `AutoShape` objektumot, amelynek a `ShapeType` értéke `Rectangle`, és helyezze el a dián a megadott pozícióban, majd szerezze meg az újonnan hozzáadott AutoShape objektum hivatkozását.  
4. Adj hozzá egy `TextFrame`‑et az `AutoShape` objektumhoz, amelynek alapértelmezett szövege *Aspose TextBox*.  
5. Hozza létre az `IHyperlinkManager` osztály egy példányát.  
6. Rendelje hozzá az `IHyperlinkManager` objektumot a [set_HyperlinkClick](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) metódushoz, amely a `TextFrame` kívánt részéhez kapcsolódik.  
7. Végül írja ki a PPTX fájlt a `Presentation` objektumon keresztül.  

```cpp
// Példányosít egy Presentation osztályt, amely egy PPTX-et képvisel
auto presentation = System::MakeObject<Presentation>();

// Lekéri a prezentáció első diáját
auto slide = presentation->get_Slides()->idx_get(0);

// Hozzáad egy AutoShape objektumot, amelynek típusa Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Átkastolja az alakzatot AutoShape-re
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Eléri az AutoShape-hez kapcsolódó ITextFrame tulajdonságot
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Szöveget ad a kerethez
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Beállítja a hiperhivatkozást a részlet szövegéhez
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Elmenti a PPTX prezentációt
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Mi a különbség a szövegdoboz és a szöveghelytartó között mesterdiák használatakor?**

Egy [placeholder](/slides/hu/cpp/manage-placeholder/) örökli a stílust és a pozíciót a [master](https://reference.aspose.com/slides/hu/cpp/aspose.slides/masterslide/)‑től, és felülírható a [layouts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/layoutslide/)‑on, míg egy normál szövegdoboz egy független objektum egy adott dián, és nem változik, ha elrendezést vált.

**Hogyan lehet tömeges szövegcserét végrehajtani a prezentációban anélkül, hogy a diagramok, táblázatok és SmartArt szövegét módosítanánk?**

Korlátozza az iterációt azokra az autoshape‑ekre, amelyeknek van szövegkeretük, és hagyja ki a beágyazott objektumokat ([charts](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/hu/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/smartart/)) úgy, hogy külön gyűjteményeikben járja be őket, vagy egyszerűen kihagyja ezeket a típusokat.