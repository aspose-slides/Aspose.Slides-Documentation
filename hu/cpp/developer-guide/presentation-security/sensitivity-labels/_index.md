---
title: Érzékenységi címkék kezelése PowerPoint bemutatókban C++-ban
linktitle: Érzékenységi címkék
type: docs
weight: 50
url: /hu/cpp/sensitivity-labels/
keywords:
- érzékenységi címke
- Microsoft Purview
- Microsoft Information Protection
- MIP metaadatok
- tartalomjelölés
- információvédelem
- dokumentumirányítás
- PowerPoint
- PPTX
- bemutató biztonság
- C++
- Aspose.Slides
description: "Olvassa, adja hozzá, frissítse, távolítsa el és migrálja a Microsoft Purview érzékenységi címkéket PowerPoint PPTX bemutatókban az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

A Microsoft Purview érzékenységi címkék segítik a szervezeteket a dokumentumok besorolásában és kormányzásában. Az automatikus bemutatófeldolgozás során egy alkalmazásnak meg kell őriznie egy meglévő címkét, alkalmaznia kell egy politikával kiválasztott címkét, frissítenie kell annak állapotát, vagy migrálnia kell egy régebbi Microsoft Information Protection (MIP) munkafolyamat által írt címke‑metaadatot.

Az Aspose.Slides a modern érzékenységi címke metaadatokat az [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) segítségével teszi elérhetővé. Ez a metódus egy [ISensitivityLabelCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabelcollection/) objektumot ad vissza, amely a bemutató PPTX‑ként való mentése előtt ellenőrizhető és módosítható.

{{% alert color="info" title="Megjegyzés" %}}
Az érzékenységi címke azonosítókat és a politikai információkat a Microsoft Purview konfigurációja határozza meg. A címkék elérhetőségét és a politikai követelményeket ellenőrizze a környezetében, mielőtt metaadatokat adna hozzá vagy migrálná őket. Az [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) értékek leírják a címkéhez kapcsolódó tartalomjelöléseket; önmagukban nem adnak hozzá látható szöveget vagy alakzatokat a diákhoz.
{{% /alert %}}

## **Érzékenységi címke tulajdonságainak megértése**

Minden [ISensitivityLabel](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/) a következő metaadatokat tartalmazza:

| Elérők | Cél |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/set_id/) | Azonosítja az érzékenységi címkét a Purview szabályzatban. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Azonosítja a címképolitikához tartozó helyet. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Jelzi, hogy a címke engedélyezett‑e. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Jelzi, hogy a címkét eltávolították. Állítsa az értéket `true`‑ra, ha a eltávolítási állapotot meg kell őrizni a metaadatokban. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Megadja, hogy a címkét automatikusan vagy felhasználói döntés alapján alkalmazták. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Felsorolja a címkéhez kapcsolódó tartalomjelölési típusokat. |

A [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelassignmenttype/) felsorolás leírja, hogyan lett egy címke hozzárendelve:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelassignmenttype/) egy alapértelmezett vagy automatikusan alkalmazott címkét jelöl.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelassignmenttype/) egy felhasználói döntés alapján alkalmazott címkét jelöl, beleértve a kézi, ajánlott és kötelező címkéket.

A [SensitivityLabelContentType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelcontenttype/) felsorolás azonosítja a címkéhez tartozó jelölést:

| Érték | Jelentés |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelcontenttype/) | A címkét alapértelmezés szerint vagy automatikusan alkalmazták. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelcontenttype/) | A címkéhez fejléc tartalomjelölés tartozik. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelcontenttype/) | A címkéhez lábléc tartalomjelölés tartozik. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelcontenttype/) | A címkéhez vízjel tartalomjelölés tartozik. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelcontenttype/) | A címkéhez titkosítási védelem tartozik. |

Több jelöléstípus is kapcsolódhat egy címkéhez.

## **Meglévő érzékenységi címkék listázása**

Olvassa be a modern címkegyűjteményt az [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) segítségével, és iterálja végig. Az alábbi példa minden címkéhez tárolt tulajdonságot és tartalomjelölést listáz:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <system/collections/ilist.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Presentation;
using System::Console;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    auto siteIdentifier = sensitivityLabel->get_SiteId();
    auto isEnabled = sensitivityLabel->get_IsEnabled();
    auto isRemoved = sensitivityLabel->get_IsRemoved();
    auto assignmentMethod = sensitivityLabel->get_AssignmentMethodType();

    Console::WriteLine(u"Label ID: {0}", labelIdentifier);
    Console::WriteLine(u"Site ID: {0}", siteIdentifier);
    Console::WriteLine(u"Enabled: {0}", isEnabled);
    Console::WriteLine(u"Removed: {0}", isRemoved);
    Console::WriteLine(u"Assignment method: {0}", assignmentMethod);

    for (auto contentMarkType : sensitivityLabel->get_ContentMarkTypes())
    {
        Console::WriteLine(u"Content marking: {0}", contentMarkType);
    }
}

presentation->Dispose();
```

## **Érzékenységi címke hozzáadása tartalomjelöléssel**

Használja az [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabelcollection/add/) metódust a címkeazonosítóval, a helyazonosítóval, az engedélyezett állapottal és a hozzárendelési módszerrel. Miután a metódus visszaadja az új [ISensitivityLabel](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/) objektumot, adja hozzá a szükséges jelölési értékeket az [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) segítségével.

Az alábbi példa egy manuálisan kiválasztott címkét ad hozzá, amely lábléc és vízjel jelölésekkel van összekapcsolva, majd az eredményt PPTX‑ként menti:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <Export/SaveFormat.h>
#include <system/collections/ilist.h>
#include <system/guid.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::SensitivityLabelContentType;
using Aspose::Slides::Export::SaveFormat;
using System::Guid;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

auto labelIdentifier = u"{11111111-2222-3333-4444-555555555555}";
auto siteIdentifier = Guid::Parse(u"{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
bool isEnabled = true;
auto assignmentMethod = SensitivityLabelAssignmentType::Privileged;

auto sensitivityLabel = sensitivityLabels->Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Footer);
sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Watermark);

presentation->Save(u"presentation_with_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Érzékenységi címke frissítése**

Az [ISensitivityLabel] értékek olvashatók/írhatók a getter és setter metódusokon keresztül, kivéve, hogy a [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) által visszaadott gyűjteményt a lista műveleteken keresztül módosítjuk. A szükséges címke megtalálása után frissítheti annak azonosítóját, helyazonosítóját, engedélyezett állapotát, hozzárendelési módját, eltávolítási állapotát és a tartalomjelölési típusokat. Mentse a bemutatót a változások rögzítéséhez.

Az alábbi példa frissíti az első címke engedélyezett állapotát és hozzárendelési módszerét:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
int labelCount = sensitivityLabels->get_Count();

if (labelCount > 0)
{
    auto sensitivityLabel = sensitivityLabels->idx_get(0);
    sensitivityLabel->set_IsEnabled(true);
    sensitivityLabel->set_AssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
}

presentation->Save(u"presentation_with_updated_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Érzékenységi címke megjelölése eltávolítottként**

A címke eltávolításának megtartásához keresse meg a címkét, és hívja meg a [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/set_isremoved/) metódust `true` értékkel. Ez megtartja a címke bejegyzését, miközben rögzíti az eltávolítási állapotát. Ha ehelyett a modern gyűjteményből kell egy bejegyzést törölni, használja az [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabelcollection/removeat/) metódust; minden bejegyzés törléséhez használja az [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabelcollection/clear/) metódust.

Az alábbi példa egy adott címkét megjelöl eltávolítottként, és menti a frissített bemutatót:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
auto targetLabelIdentifier = u"{11111111-2222-3333-4444-555555555555}";

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    bool isTargetLabel = String::Equals(
        labelIdentifier,
        targetLabelIdentifier,
        StringComparison::OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel->set_IsRemoved(true);
        break;
    }
}

presentation->Save(u"presentation_with_removed_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Legacy MIP érzékenységi címkék beolvasása és migrálása**

A régebbi, MIP‑alapú munkafolyamatok a modern címkegyűjtemény helyett egyedi dokumentum tulajdonságokban tárolhatják az érzékenységi címke metaadatait. Olvassa be ezeket a metaadatokat az [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) metódussal. A metódus feldolgozza a régi egyedi tulajdonságokat, és egy [ISensitivityLabel](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/) objektumok tömbjét adja vissza.

A metaadatok migrálásához adja hozzá minden visszakapott címkét a modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabelcollection/) gyűjteményhez az [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabelcollection/add/) segítségével. Mivel egy duplikált címkeazonosító hozzáadása kivételt okoz, a példa a másolás előtt ellenőrzi a célgyűjteményt. További érvényesítést is hozzáadhat, hogy megerősítse, minden régi címke továbbra is létezik‑e a jelenlegi Purview politikában.

```cpp
#include <DOM/Presentation.h>
#include <DOM/IDocumentProperties.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation_with_legacy_labels.pptx");
auto documentProperties = presentation->get_DocumentProperties();
auto legacySensitivityLabels = documentProperties->GetSensitivityLabels();
auto modernSensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& legacySensitivityLabel : legacySensitivityLabels)
{
    bool labelAlreadyExists = false;
    auto legacyLabelIdentifier = legacySensitivityLabel->get_Id();

    for (auto&& modernSensitivityLabel : modernSensitivityLabels)
    {
        auto modernLabelIdentifier = modernSensitivityLabel->get_Id();
        labelAlreadyExists = String::Equals(
            modernLabelIdentifier,
            legacyLabelIdentifier,
            StringComparison::OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels->Add(legacySensitivityLabel);
    }
}

presentation->Save(u"presentation_with_modern_labels.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A migráció a feldolgozott címkeobjektumokat átmásolja a modern gyűjteménybe. Nem szükséges az összes egyedi dokumentum tulajdonságot törölni, így a nem kapcsolódó dokumentum metaadatok érintetlenek maradnak. Használja az [IPresentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/save/) metódust a [SaveFormat::Pptx](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveformat/) értékkel a modern címke metaadatok PPTX fájlba írásához.

## **GYIK**

**A tartalomjelölési típus hozzáadása látható fejlécet, láblécet vagy vízjelet hoz‑e létre a diákon?**  
Nincs. A [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) segítségével hozzáadott értékek a címkéhez kapcsolódó jelöléseket írják le; nem hoznak létre látható szöveget vagy alakzatot a bemutatóban. Ha a munkafolyamatnak meg kell jelenítenie ezeket a jelöléseket, adja hozzá a megfelelő diatartalmat külön.

**Mi a különbség a címke eltávolítottként való megjelölése és a gyűjteményből való törlése között?**  
A [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/set_isremoved/) metódus `true` értékkel történő hívása megtartja a címke bejegyzését és rögzíti az eltávolítási állapotot. Az [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabelcollection/removeat/) metódus hívása törli a bejegyzést a modern gyűjteményből. Válassza azt a műveletet, amely a szervezet metaadat‑megőrzési követelményeinek megfelel.

**Tartalmazhat egy bemutató egyaránt régi MIP metaadatokat és modern érzékenységi címkéket?**  
Igen. A régi címkék megmaradhatnak az egyedi dokumentumtulajdonságokban, míg a modern címkék az [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) segítségével érhetők el. Használja az [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) metódust a régi metaadatok beolvasásához, és csak azokat a valid címkéket migrálja, amelyek még nem szerepelnek a modern gyűjteményben.

**Mi történik, ha egy azonosítóval rendelkező címkét többször is hozzáadnak?**  
Az [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabelcollection/add/) argumentum kivételt dob, ha a gyűjtemény már tartalmaz egy ugyanazzal az azonosítóval rendelkező címkét. Ellenőrizze a meglévő [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_id/) értékeket a címkék hozzáadása vagy migrálása előtt.

**Melyik kimeneti formátumot kell használni a frissített érzékenységi címkék megőrzéséhez?**  
Mentse a bemutatót PPTX formátumban az [IPresentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/save/) metódus [SaveFormat::Pptx](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveformat/) paraméterrel történő meghívásával, ahogy a fenti példákban is látható.