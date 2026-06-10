---
title: Diák eltávolítása a prezentációkból C++-ban
linktitle: Dia eltávolítása
type: docs
weight: 30
url: /hu/cpp/remove-slide-from-presentation/
keywords:
- dia eltávolítása
- dia törlése
- használaton kívüli dia eltávolítása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Egyenesen eltávolíthat diákot a PowerPoint és OpenDocument prezentációkból az Aspose.Slides for C++ segítségével. Kapjon világos kódrészleteket és fokozza a munkafolyamatát."
---
## **Bevezetés**

Ha egy dia (vagy annak tartalma) feleslegessé válik, törölheti azt. Az Aspose.Slides a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályt biztosítja, amely magába foglalja a [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) elemet, ami a bemutató összes dia tárolója. Egy ismert [ISlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/) objektumra mutató mutató (referencia vagy index) használatával megadhatja a törlendő diát. 

## **Dia eltávolítása referenciával**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
1. Szerezze meg a törlendő dia referenciáját azonosítója vagy indexe alapján.  
1. Távolítsa el a hivatkozott diát a bemutatóból.  
1. Mentse a módosított bemutatót.  

Az alábbi C++ kód bemutatja, hogyan távolítható el egy dia a referenciája alapján: 

```c++
	// A dokumentumok könyvtárának elérési útja
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Létrehozza a Presentation objektumot, amely egy prezentációs fájlt képvisel
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Eléri a diát a diatárgyak gyűjteményében lévő indexe alapján
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Eltávolít egy diát a referenciája alapján
	pres->get_Slides()->Remove(slide);

	// Elmenti a módosított prezentációt
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Dia eltávolítása index szerint**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
1. Távolítsa el a diát a bemutatóból az indexhelye alapján.  
1. Mentse a módosított bemutatót.  

Az alábbi C++ kód bemutatja, hogyan távolítható el egy dia az indexe alapján: 

```c++
	// A dokumentumok könyvtárának elérési útja
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Létrehozza a Presentation objektumot, amely egy prezentációs fájlt képvisel
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Eltávolít egy diát a dia indexe alapján
	pres->get_Slides()->RemoveAt(0);

	// Elmenti a módosított prezentációt
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Használaton kívüli elrendezési diák eltávolítása**

Az Aspose.Slides a [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metódust (a [Compress](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/) osztályból) biztosítja, amely lehetővé teszi a nem kívánt és használaton kívüli elrendezési diák törlését. Az alábbi C++ kód bemutatja, hogyan távolítható el egy elrendezési dia egy PowerPoint bemutatóból:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Használaton kívüli mester diák eltávolítása**

Az Aspose.Slides a [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) metódust (a [Compress](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/) osztályból) biztosítja, amely lehetővé teszi a nem kívánt és használaton kívüli mester diák törlését. Az alábbi C++ kód bemutatja, hogyan távolítható el egy mester dia egy PowerPoint bemutatóból:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Mi történik a diák indexeivel, miután egy diát törlök?**

Törlés után a [collection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slidecollection/) újraindexel: minden azt követő dia balra tolódik egy pozícióval, így a korábbi indexek elavulnak. Ha stabil hivatkozásra van szüksége, használja a dia állandó azonosítóját az index helyett.

**Eltérő a dia azonosítója az indexétől, és változik-e, amikor a szomszédos diák törlésre kerülnek?**

Igen. Az index a dia pozíciója, és a diák hozzáadása vagy eltávolítása esetén megváltozik. A dia ID egy állandó azonosító, amely nem változik, ha más diák törlésre kerülnek.

**Hogyan befolyásolja egy dia törlése a diarészleteket?**

Ha a dia egy szekcióhoz tartozott, az a szekció egyszerűen egy diával kevesebbet tartalmaz majd. A szekció struktúrája változatlan marad; ha egy szekció üressé válik, akkor [szekciók eltávolítása vagy átrendezése](/slides/hu/cpp/slide-section/) elvégezhető szükség szerint.

**Mi történik a diahoz csatolt jegyzetekkel és megjegyzésekkel, ha azt törlik?**

[Notes](/slides/hu/cpp/presentation-notes/) és [comments](/slides/hu/cpp/presentation-comments/) az adott diahoz vannak kötve, és a dia törlésével együtt eltávolításra kerülnek. Más diák tartalma érintetlen marad.

**Miben különbözik a diák törlése a használaton kívüli elrendezések/mesterek tisztításától?**

A törlés konkrét, normál diák eltávolítását jelenti a prezentációból. A használaton kívüli elrendezések/mesterek tisztítása olyan elrendezési vagy mester diákat vesz el, amelyeket senki sem hivatkozik, ezáltal csökkentve a fájlméretet anélkül, hogy a maradék diák tartalma megváltozna. Ezek a műveletek kiegészítik egymást: általában először töröl, majd tisztít.