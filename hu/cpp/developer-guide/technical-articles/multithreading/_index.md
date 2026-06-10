---
title: Többszálúság az Aspose.Slides for C++-ban
linktitle: Többszálúság
type: docs
weight: 200
url: /hu/cpp/multithreading/
keywords:
- többszálúság
- több szál
- párhuzamos munka
- diák konvertálása
- diák képekké
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Az Aspose.Slides for C++ többszálúsága felgyorsítja a PowerPoint és OpenDocument feldolgozást. Fedezze fel a leghatékonyabb prezentációs munkafolyamatok legjobb gyakorlatait."
---
## **Bevezetés**

Miközben a prezentációk párhuzamos feldolgozása (a feldolgozás/ betöltés/ klónozás mellett) lehetséges, és a legtöbbször minden rendben működik, kis valószínűséggel helytelen eredményeket kaphatsz, ha a könyvtárat több szálon használod.

Erősen javasoljuk, hogy **ne** használj egyetlen [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) példányt több szálas környezetben, mert előre nem látható hibákhoz vagy nehezen észlelhető meghibásodásokhoz vezethet.

Nem **biztonságos** betölteni, menteni és/vagy klónozni egy [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztálypéldányt több szálon. Az ilyen műveletek **nem** támogatottak. Ha ilyen feladatokat kell végrehajtanod, párhuzamosan kell futtatnod a műveleteket több egy-szálas folyamat segítségével – és minden folyamatnak saját prezentációpéldányt kell használnia.

## **Prezentációs diák párhuzamos konvertálása képekké**

Tegyük fel, hogy az összes diákat egy PowerPoint prezentációból párhuzamosan PNG képekké szeretnénk konvertálni. Mivel nem biztonságos egyetlen `Presentation` példányt több szálon használni, a prezentáció diáit különálló prezentációkra bontjuk, és a diákat párhuzamosan képekké alakítjuk, minden prezentációt külön szálban használva. Az alábbi kódrészlet bemutatja, hogyan lehet ezt megvalósítani.

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Kivonja a i. diát egy külön prezentációba.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Átalakítja a diát egy képpé egy külön feladatban.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// Várja meg, hogy az összes feladat befejeződjön.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```

## **GYIK**

**Szükséges minden szálban meghívni a licencbeállítást?**

Nem. Elég egyszer elvégezni a folyamat/applikáció tartomány szintjén, mielőtt a szálak elindulnak. Ha a [licencbeállítás](/slides/hu/cpp/licensing/) párhuzamosan is meghívható (például a lusta inicializálás során), szinkronizáld a hívást, mert a licencbeállítási metódus önmagában nem szálbiztos.

**Átadhatok `Presentation` vagy `Slide` objektumokat szálak között?**

Élő prezentációobjektumok szálak közötti átvitele nem ajánlott: használj szálanként független példányokat, vagy előre hozd létre a külön prezentációkat/diakonténereket minden szálhoz. Ez a megközelítés összhangban áll az általános ajánlással, miszerint ne ossz meg egyetlen prezentációpéldányt a szálak között.

**Biztonságos-e több formátumba (PDF, HTML, képek) történő exportot párhuzamosan végrehajtani, ha minden szálnak saját `Presentation` példánya van?**

Igen. Független példányokkal és külön kimeneti útvonalakkal az ilyen feladatok általában helyesen párhuzamosíthatók; kerüld a megosztott prezentációobjektumokat és a közös I/O áramlatokat.

**Mit tegyek a globális betűtípus beállításokkal (mappák, helyettesítések) több szálas környezetben?**

Inicializáld az összes globális betűtípus-beállítást a szálak indítása előtt, és ne módosítsd őket a párhuzamos munka során. Ez megszünteti a versenyhelyzeteket a megosztott betűtípus-erőforrások elérésekor.