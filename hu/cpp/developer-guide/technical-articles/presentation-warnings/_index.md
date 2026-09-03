---
title: Prezentáció figyelmeztetések kezelése C++-ban
type: docs
weight: 70
url: /hu/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- figyelmeztetés visszahívás
- figyelmeztetési szabályzat
- adatveszteség
- forrás korruptság
- kompatibilitási probléma
- betűkészlet helyettesítés
- digitális aláírás
- prezentáció betöltése
- prezentáció renderelése
- prezentáció konvertálása
- prezentáció mentése
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan gyűjthető össze, osztályozható és kezelhető a figyelmeztetések a prezentációk betöltése, renderelése, konvertálása és mentése során az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

Az Aspose.Slides visszajelzéseket adhat a helyrehozható problémákról, amikor betölti, megjeleníti, konvertálja vagy menti a prezentációt. Példák a sérült forrás rekordokra, a nem megőrizhető tartalomra, a betűkészlet helyettesítésre és a célformátum korlátaira. Egy figyelmeztetési visszahívás lehetővé teszi az alkalmazás számára, hogy rögzítse ezeket a feltételeket, és eldöntse, hogy a jelenlegi művelet folytatható‑e.

Implementálja a [IWarningCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides.warnings/iwarningcallback/) interfészét, és vizsgálja meg a [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) valamint a [IWarningInfo::get_Description](https://reference.aspose.com/slides/hu/cpp/aspose.slides.warnings/iwarninginfo/get_description/) metódusokat, amelyeket az [IWarningInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides.warnings/iwarninginfo/) biztosít. Adja vissza a [ReturnAction::Continue](https://reference.aspose.com/slides/hu/cpp/aspose.slides.warnings/returnaction/) értéket a figyelmeztetés elfogadásához, vagy a `ReturnAction::Abort` értéket a művelet leállításához.

Használja a [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_warningcallback/) metódust a prezentáció megnyitásakor keletkező figyelmeztetésekhez. A renderelés és exportálási opcióosztályok öröklik a [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveoptions/set_warningcallback/) metódust, amely a dia rendereléséből, konvertálásából és mentéséből származó figyelmeztetéseket kapja. Mivel a figyelmeztetés önmagában nem azonosítja az alkalmazás műveletét, társítsa minden visszahíváspéldányt egy műveleti szakaszhoz, amikor egy összesített jelentést készít.

## **Figyelmeztetések és Kivétel**

Figyelmeztetés azt a feltételt írja le, amelyből az Aspose.Slides helyrehozható, ha a visszahívás `ReturnAction::Continue` értékkel tér vissza. Egy kivétel azt jelenti, hogy a kért művelet nem fejezhető be normálisan; a kivételek nem konvertálódnak figyelmeztetésre, és nem kezelhetők figyelmeztetési szabályozással.

A `ReturnAction::Abort` visszaadása azt kéri a figyelmeztetés‑diszpatchert, hogy a jelenlegi műveletet egy kivétellel szakítsa meg. A nyilvános kivétel a művelettől és a prezentáció formátumától függ. Például a betöltés során egy [PptxReadException](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pptxreadexception/) vagy [PptReadException](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pptreadexception/) jelenhet meg, míg a mentés vagy exportálás során egy [PptxException](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pptxexception/) fordulhat elő. Kezelje a kivételt a művelet határán, és használja a figyelmeztetési jelentést annak meghatározására, hogy az alkalmazás szabályzata okozta‑e a leállást, ahelyett, hogy egyetlen kivétel alosztályra vagy üzenetre támaszkodna. A visszahívás a figyelmeztetést rögzíti, mielőtt a `ReturnAction::Abort` értéket visszaadná, biztosítva, hogy az ok továbbra is elérhető legyen az alkalmazás számára.

## **Figyelmeztetési kategóriák**

Az [WarningType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.warnings/warningtype/) felsorolás a következő kategóriákat biztosítja:

| Figyelmeztetés típusa | Jelentés | Tipikus szabályzat |
| --- | --- | --- |
| `SourceFileCorruption` | A forrás prezentáció sérülést tartalmaz, amely miatt az eredeti formátumban mentett dokumentum használhatatlanná válhat. | Abort. |
| `DataLoss` | Szöveg, diagramok, képek vagy más adatok hiányozhatnak a betöltés vagy mentés után. | Abort. |
| `MajorFormattingLoss` | A prezentáció jelentős formázási információkat veszíthet. | Abort szigorú ellenőrzési módban; egyébként rögzítse és folytassa. |
| `MinorFormattingLoss` | Korlátozott formázási eltérés előfordulhat. | Rögzítse diagnosztikai célokra és folytassa. |
| `CompatibilityIssue` | Az eredmény előfordulhat, hogy nem nyílik meg vagy nem működik megfelelően néhány alkalmazásban vagy régebbi verzióban. | Naplózza és folytassa, hacsak a kompatibilitás nem kötelező. |
| `UnexpectedContent` | A forrás nem támogatott vagy ismeretlen tartalmat tartalmaz, amelynek hatása még ismeretlen lehet. | Rögzítse és folytassa, vagy szigorú szabályzat esetén kezelje hibaként. |

A kategória határozza meg a szabályzat döntését. Tartsa meg a figyelmeztetés leírását diagnosztikai célokra, de ne támaszkodjon a szövegre az alkalmazáslogikában, mivel az üzenet szövege változhat a figyelmeztetési helyzetek és a termék verziók között.

## **Figyelmeztetések összegyűjtése és osztályozása**

A következő példa egy alkalmazásszintű jelentést használ a teljes feldolgozási folyamatra. Egy különálló visszahíváspéldány címkézi a betöltés, renderelés, PDF konvertálás és PPTX mentés során keletkező figyelmeztetéseket. A szabályzat forrássérülés vagy adatveszteség esetén megszakít, opcionálisan nagy formázási veszteség esetén is, és a többi figyelmeztetésnél folytat.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

Állítsa a `abortOnMajorFormattingLoss` értékét `false`‑ra, ha a nagy formázási eltérések elfogadhatók. A kompatibilitási problémák, kisebb formázási veszteség és a váratlan tartalom továbbra is szerepelnek a jelentésben, még akkor is, ha a művelet folytatódik. Bővítse a `WarningPolicy::GetAction` metódust, ha az alkalmazásnak el kell utasítania bármelyik ilyen kategóriát.

## **Általános Figyelmeztetési Forgatókönyvek**

- **Digitális aláírások:** Egy aláírt prezentáció betöltéskor figyelmeztetést adhat, hogy az aláírás a feldolgozás során elveszik. Az Aspose.Slides ezt a `DataLoss` állapotot a [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/) segítségével jelenti. Egy betöltési szakaszban futó visszahívás lehetővé teszi az alkalmazás számára, hogy elutasítsa a fájlt vagy kifejezetten elfogadja a jelentett veszteséget.
- **Betűkészlet helyettesítés:** Egy nem elérhető betűkészlet helyettesíthető, miközben egy diát renderelnek vagy exportálnak. A betűkészlet helyettesítés figyelmeztetéseket `DataLoss`‑ként jelentik, ezért a fentebb leírt szigorú szabályzat még akkor is megszakít, ha az alkalmazás a helyettesítést vizuálisan elfogadhatónak tartja. Ennek megfigyeléséhez használjon egy bemeneti prezentációt, amelyben olyan betűkészlet van, amely a futási környezetben nem érhető el. A figyelmeztetés leírása azonosítja a helyettesítést; konfigurálja a szükséges betűkészleteket vagy a [betűkészlet helyettesítési szabályokat](/slides/hu/cpp/font-substitution/) a újrapróbálás előtt.
- **Nem támogatott vagy váratlan tartalom:** A betöltő olyan prezentációs rekordokkal vagy funkciókkal találkozhat, amelyeket nem ismer fel. Az ilyen figyelmeztetések használhatják a `UnexpectedContent` típust, vagy súlyosabb kategóriát, ha a adatok vagy a formázás is érintett.
- **Formátum kompatibilitás:** Egy másik prezentációformátumba történő mentés kihagyhat funkciókat vagy olyan eredményt hozhat létre, amely különböző módon viselkedik egyes alkalmazásokban. Például egy prezentáció mentése, amely több mint nyolc vízszintes vagy nyolc függőleges rajzsegédet tartalmaz, a régi PPT formátumba `CompatibilityIssue`‑t jelent. A mentési szakasz visszahívása rögzítheti a veszteséget és folytathatja, vagy elutasíthatja, ha az összes segéd megőrzése kötelező.
- **Betöltési viselkedés:** A betöltési beállítások és a régi viselkedések is generálhatnak figyelmeztetéseket. Például a [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) egy elavult prezentáció‑zárolási viselkedés használatát `CompatibilityIssue`‑ként azonosítja.

A figyelmeztetések a forrásdokumentumtól, a célformátumtól, a művelettől és az Aspose.Slides verziójától függenek. Ne feltételezze, hogy minden fájl figyelmeztetést generál, vagy hogy egy forgatókönyv mindig csak egy kategóriába sorolható.

## **A megszakított műveletek biztonságos kezelése**

Amikor egy visszahívás `ReturnAction::Abort` értékkel tér vissza, ne használjon olyan objektumot, amely betöltése sikertelen volt, és ne feltételezze, hogy a renderelés vagy mentés kimenete teljes. A művelet a kimeneti fájl létrehozása után, de annak befejezése előtt is befejezhető.

Mentse a validált eredményeket egy külön útvonalra, például `validated-output.pptx`. Cserélje le a meglévő prezentációt csak akkor, amikor a művelet sikeresen befejeződött, a figyelmeztetési jelentés megfelel az alkalmazás szabályzatának, és a kimenet megnyitható és ellenőrizhető. Ez elkerüli, hogy egy érvényes forrásfájlt egy részleges vagy elutasított eredménnyel írjon felül.

Egy üres figyelmeztetési jelentés nem garantálja, hogy minden forrásjellemző megmaradt. Alkalmazzon minden további tartalom‑ és vizuális ellenőrzést, amely az alkalmazás megkövetel. Lásd még a [Open Presentations](/slides/hu/cpp/open-presentation/) és a [Save Presentations](/slides/hu/cpp/save-presentation/) oldalakat.

## **GYIK**

**Kezelhet egy figyelmeztetési visszahívás minden Aspose.Slides hibát?**

Nem. Csak a figyelmeztetésként jelentett helyrehozható feltételeket kezeli. Azokat a kivételeket, amelyek a visszahívástól függetlenül fordulnak elő, az alkalmazásnak kell kezelnie a betöltés, renderelés, konvertálás vagy mentés hívása körül.

**Garantálja a `ReturnAction::Continue` visszatérés azonos kimenetet?**

Nem. Csak engedélyezi a feldolgozás folytatását. A jelentett feltétel továbbra is adat‑, formázási vagy kompatibilitási különbségeket okozhat, ezért ellenőrizze a gyűjtött figyelmeztetéstípusokat és leírásokat.

**Hogyan tudja az alkalmazás azonosítani a figyelmeztetést előállító műveletet?**

Hozzon létre egy visszahíváspéldányt minden művelethez, és tárolja az alkalmazás által definiált szakaszt a figyelmeztetés típussal és leírással együtt, ahogyan a példában látható.