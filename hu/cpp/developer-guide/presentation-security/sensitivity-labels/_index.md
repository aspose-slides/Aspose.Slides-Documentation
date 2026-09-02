---
title: Érzékenységi címkék kezelése PowerPoint-prezentációkban C++-ban
linktitle: Érzékenységi címkék
type: docs
weight: 50
url: /hu/cpp/sensitivity-labels/
keywords:
- érzékenységi címke
- Microsoft Purview
- Microsoft Information Protection
- MIP metaadat
- tartalomjelölés
- információvédelem
- dokumentumirányítás
- PowerPoint
- PPTX
- prezentációbiztonság
- C++
- Aspose.Slides
description: "Olvassa, adja hozzá, frissítse, távolítsa el és migrálja a Microsoft Purview érzékenységi címkéket PowerPoint PPTX prezentációkban az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

A Microsoft Purview szenzitivitási címkék segítik a szervezeteket a dokumentumok osztályozásában és irányításában. Automatizált prezentációfeldolgozás során egy alkalmazásnak meg kell őriznie egy meglévő címkét, egy szabályzat által kiválasztott címkét kell alkalmaznia, frissítenie kell annak állapotát, vagy át kell migrálnia egy régebbi Microsoft Information Protection (MIP) munkafolyamat által írt címke metaadatait.

Az Aspose.Slides a modern szenzitivitási címke metaadatait a [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) segítségével teszi elérhetővé. Ez a metódus egy [ISensitivityLabelCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabelcollection/)-t ad vissza, amelyet a prezentáció PPTX formátumban mentése előtt megtekinthet és módosíthat.

{{% alert color="primary" title="Megjegyzés" %}}

A szenzitivitási címke azonosítókat és a szabályzati információkat a Microsoft Purview konfigurációja határozza meg. Ellenőrizze a címkék elérhetőségét és a szabályzat követelményeit a környezetében, mielőtt metaadatot adna hozzá vagy migrálná. A [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) értékek a címkéhez kapcsolódó tartalomjelöléseket írják le; önmagukban nem adnak hozzá látható szöveget vagy alakzatot a diákhoz.

{{% /alert %}}

## **A szenzitivitási címke tulajdonságainak megértése**

Minden [ISensitivityLabel](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/) a következő metaadatokat tartalmazza:

| Elérők | Cél |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/set_id/) | Azonosítja a szenzitivitási címkét a Purview szabályzatban. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Azonosítja a címkét szabályozó webhelyet. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Jelzi, hogy a címke engedélyezve van-e. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Jelzi, hogy a címkét eltávolították. Állítsa `true`‑ra, ha a eltávolítási állapotot metaadatként meg kell tartani. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Megadja, hogy a címkét automatikusan vagy felhasználói döntés alapján alkalmazták-e. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Felsorolja a címkéhez kapcsolódó tartalomjelölés típusokat. |

A [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelassignmenttype/) felsorolás leírja, hogyan lett a címke hozzárendelve:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelassignmenttype/) egy alapértelmezett vagy automatikusan alkalmazott címkét jelöl.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelassignmenttype/) egy felhasználói döntés alapján alkalmazott címkét jelöl, beleértve a manuálisan, ajánlottan és kötelezően alkalmazott címkéket.

A [SensitivityLabelContentType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelcontenttype/) felsorolás azonosítja a címkéhez kapcsolódó jelölést:

| Érték | Jelentés |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelcontenttype/) | A címkét alapértelmezés szerint vagy automatikusan alkalmazták. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelcontenttype/) | A címkéhez fejléc tartalomjelölés kapcsolódik. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelcontenttype/) | A címkéhez lábléc tartalomjelölés kapcsolódik. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelcontenttype/) | A címkéhez vízjel tartalomjelölés kapcsolódik. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sensitivitylabelcontenttype/) | A címkéhez titkosítási védelem kapcsolódik. |

Több jelöléstípus is társítható egy címkéhez.

## **Meglévő szenzitivitási címkék listázása**

Olvassa be a modern címkegyűjteményt a [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) segítségével, és enumerálja azt. Az alábbi példa felsorolja minden címke összes tulajdonságát és a tárolt tartalomjelöléseket:

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

## **Szenzitivitási címke hozzáadása tartalomjelöléssel**

Használja a [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabelcollection/add/) metódust a címkeazonosító, a webhelyazonosító, az engedélyezési állapot és a hozzárendelési mód megadásával. A metódus visszatér egy új [ISensitivityLabel](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/) objektummal; ezután adja hozzá a szükséges jelölésértékeket a [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) segítségével.

Az alábbi példa manuálisan kiválasztott címkét ad hozzá, amely lábléc és vízjel jelölésekkel kapcsolódik, majd PPTX‑ként menti az eredményt:

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

## **Szenzitivitási címke frissítése**

Az [ISensitivityLabel](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/) értékei olvashatóak/írhatóak a getter és setter metódusokon keresztül, kivéve a [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) által visszaadott gyűjteményt, amelyet a lista műveletekkel módosítanak. A szükséges címke megtalálása után frissítheti annak azonosítóját, webhelyazonosítóját, engedélyezési állapotát, hozzárendelési módját, eltávolítási állapotát és a tartalomjelölés típusait. Mentse a prezentációt a változások véglegesítéséhez.

Az alábbi példa frissíti az első címke engedélyezési állapotát és hozzárendelési módját:

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

## **Szenzitivitási címke megjelölése eltávolítottként**

Az eltávolítás tényének megőrzéséhez keresse meg a címkét, és hívja meg a [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/set_isremoved/) metódust `true`‑val. Ez megőrzi a címke bejegyzését, miközben rögzíti az eltávolított állapotát. Ha a modern gyűjteményből bejegyzést szeretne ténylegesen törölni, használja a [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabelcollection/removeat/)‑t; a [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabelcollection/clear/) minden bejegyzés törlésére használható.

Az alábbi példa egy konkrét címkét megjelöl eltávolítottként, és elmenti a frissített prezentációt:

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

## **Régi MIP szenzitivitási címkék olvasása és migrálása**

A régebbi MIP‑alapú munkafolyamatok a szenzitivitási címke metaadatait egyedi dokumentum tulajdonságokban tárolhatják a modern címkegyűjtemény helyett. Olvassa ezeket a metaadatokat a [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) segítségével. A metódus feldolgozza a régi egyedi tulajdonságokat, és egy [ISensitivityLabel](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/) objektumok tömbjét adja vissza.

A metaadatok migrálásához adja hozzá a visszaadott címkéket a modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabelcollection/) gyűjteményhez a [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabelcollection/add/) használatával. Mivel egy duplikált címkeazonosító hozzáadása kivételt dob, a példa a célgyűjteményt ellenőrzi, mielőtt minden címkét átmásolna. További ellenőrzéseket is beépíthet, hogy megerősítse, hogy az egyes régi címkék továbbra is léteznek az aktuális Purview szabályzatban.

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

A migráció a feldolgozott címkeobjektumokat a modern gyűjteménybe másolja. Nem szükséges az összes egyedi dokumentumtulajdonságot törölni, így a nem kapcsolódó dokumentum metaadatok érintetlenek maradnak. Használja a [IPresentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/save/) metódust a [SaveFormat::Pptx](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveformat/) formátummal a modern címke metaadatok PPTX fájlba írásához.

## **Gyakran Ismételt Kérdések**

**Létrehozza egy tartalomjelölés típusának hozzáadása a látható fejlécet, láblécet vagy vízjelet a diákon?**

Nem. A [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) által hozzáadott értékek a szenzitivitási címkéhez kapcsolódó jelöléseket írják le. Nem hoznak létre látható szöveget vagy alakzatot a prezentációban. Ha a munkafolyamata megjeleníti ezeket a jelöléseket, külön kell hozzáadnia a megfelelő diatartalmat.

**Mi a különbség a címke eltávolítottként jelölése és a gyűjteményből való törlése között?**

A [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/set_isremoved/) `true`‑ra állítása megtartja a címke bejegyzését és rögzíti az eltávolított állapotát. A [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabelcollection/removeat/) hívása törli a bejegyzést a modern gyűjteményből. Válassza azt a műveletet, amely megfelel a szervezet metaadat-megőrzési követelményeinek.

**Tartalmazhat egy prezentáció egyszerre régi MIP metaadatokat és modern szenzitivitási címkéket?**

Igen. A régi címkék maradhatnak az egyedi dokumentumtulajdonságokban, míg a modern címkék a [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) segítségével érhetők el. Használja a [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) metódust a régi metaadatok olvasásához, és csak a már nem jelen lévő, érvényes címkéket migrálja a modern gyűjteménybe.

**Mi történik, ha egy azonos azonosítóval rendelkező címkét többször adnak hozzá?**

A [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabelcollection/add/) argumentumkivételt dob, ha a gyűjtemény már tartalmaz egy ilyen azonosítóval rendelkező címkét. Ellenőrizze a meglévő [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isensitivitylabel/get_id/) értékeket, mielőtt címkét hozzáad vagy migrál.

**Melyik kimeneti formátumot kell használni a frissített szenzitivitási címkék megőrzéséhez?**

Mentse a prezentációt PPTX formátumban a [IPresentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/save/) metódus hívásával a [SaveFormat::Pptx](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveformat/) értékkel, ahogy a fenti példák is mutatják.