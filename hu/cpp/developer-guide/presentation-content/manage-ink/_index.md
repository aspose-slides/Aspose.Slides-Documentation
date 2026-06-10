---
title: PowerPoint tintaobjektumok kezelése C++-ban
linktitle: Tinta kezelése
type: docs
weight: 95
url: /hu/cpp/manage-ink/
keywords:
- tinta
- tintaobjektum
- tinta nyomvonal
- tinta kezelése
- tinta rajzolása
- rajzolás
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "PowerPoint tintaobjektumok kezelése – hozza létre, szerkessze és formázza a digitális tintát az Aspose.Slides C++ verziójával. Kérjen kódpéldákat nyomvonalakhoz, ecsetszínhez és mérethez."
---
## **Bevezetés**

A PowerPoint biztosítja a tinta funkciót, amely lehetővé teszi nem szabványos alakzatok rajzolását; ezeket fel lehet használni más objektumok kiemelésére, kapcsolatok és folyamatok megjelenítésére, valamint a dián lévő konkrét elemek figyelemfelkeltésére.

Az Aspose.Slides a [Aspose.Slides.Ink](https://reference.aspose.com/slides/hu/cpp/aspose.slides.ink/) felületet kínálja, amely tartalmazza a tintaobjektumok létrehozásához és kezeléséhez szükséges típusokat.

## **A szabályos objektumok és a tintaobjektok közötti különbségek**

A PowerPoint dián lévő objektumok általában shape objektumokként jelennek meg. Egy shape objektum legegyszerűbben egy tároló, amely meghatározza az objektum (keret) területét, valamint a tulajdonságait. Ezek közé tartozik a tároló területének mérete, a tároló alakja, a háttér stb. További információért lásd a [Alakzat elrendezési formátum](https://docs.aspose.com/slides/hu/cpp/shape-manipulations/#access-layout-formats-for-shape) oldalt.

Azonban amikor a PowerPoint tintaobjektummal dolgozik, figyelmen kívül hagyja a keret (tároló) minden tulajdonságát, kivéve a méretét. A tároló területének méretét a szabványos `width` és `height` értékek határozzák meg:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tintaalakú nyomvonalak**

A nyomvonal egy alapvető elem vagy szabvány, amely a toll trajektóriáját rögzíti, amikor a felhasználó digitális tintát ír. A nyomvonalak felvételi adatként leírják az összekapcsolt pontok sorozatát.

A legegyszerűbb kódolási forma minden mintapont X és Y koordinátáit adja meg. Amikor az összes összekapcsolt pont megjelenik, az alábbi képet eredményezi:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ecset tulajdonságai a rajzoláshoz**

Az ecsetet használhatja vonalak rajzolására, amelyek összekötik a nyomvonal elemek pontjait. Az ecsetnek saját színe és mérete van, amely a `Brush.Color` és `Brush.Size` tulajdonságoknak felel meg.

### **Tinta Ecset Szín beállítása**

Ez a C++ kód megmutatja, hogyan állítható be egy ecset színe:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **Tinta Ecset Méret beállítása**

Ez a C++ kód megmutatja, hogyan állítható be egy ecset mérete:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

Általában az ecset szélessége és magassága nem egyezik meg, ezért a PowerPoint nem jeleníti meg az ecset méretét (az adatmező szürke). Ha azonban az ecset szélessége és magassága megegyezik, a PowerPoint a következő módon mutatja a méretet:

![ink_powerpoint3](ink_powerpoint3.png)

Az átláthatóság kedvéért növeljük meg a tintaobjektum magasságát, és tekintsük át a fontos dimenziókat:

![ink_powerpoint4](ink_powerpoint4.png)

A tároló (keret) nem veszi figyelembe az ecsetek méretét – mindig úgy veszi, mintha a vonal vastagsága nulla lenne (lásd az utolsó képet).

Ezért a teljes tintaobjektum látható területének meghatározásához figyelembe kell venni a nyomvonal objektumok ecsetméretét. Itt a célobjektum (a kézírott szöveg nyomvonalobjektuma) a tároló (keret) méretéhez lett méretezve. Amikor a tároló (keret) mérete változik, az ecsetméret állandó marad, és fordítva.

![ink_powerpoint5](ink_powerpoint5.png)

A PowerPoint ugyanígy viselkedik a szövegekkel is:

![ink_powerpoint6](ink_powerpoint6.png)

**További olvasnivaló**

* A shape-kről általánosságban a [PowerPoint Shapes](https://docs.aspose.com/slides/hu/cpp/powerpoint-shapes/) szakaszban olvashat.
* A hatékony értékekkel kapcsolatos további információkért lásd a [Shape Effective Properties](https://docs.aspose.com/slides/hu/cpp/shape-effective-properties/#get-effective-font-height-value) oldalt.