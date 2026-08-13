---
title: "Érzékenységi címkék kezelése PowerPoint prezentációkban .NET-ben"
linktitle: "Érzékenységi címkék"
type: docs
weight: 50
url: /hu/net/sensitivity-labels/
keywords:
- "érzékenységi címke"
- "Microsoft Purview"
- "Microsoft Information Protection"
- "MIP metaadat"
- "tartalomjelölés"
- "információvédelem"
- "dokumentumirányítás"
- "PowerPoint"
- "PPTX"
- "prezentációbiztonság"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Olvassa, adja hozzá, frissítse, távolítsa el és migrálja a Microsoft Purview érzékenységi címkéket PowerPoint PPTX prezentációkban az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

A Microsoft Purview érzékenységi címkék segítik a szervezeteket a dokumentumok osztályozásában és felügyeletében. Az automatikus prezentációfeldolgozás során egy alkalmazásnak meg kell őriznie egy meglévő címkét, alkalmaznia kell egy szabály által kiválasztott címkét, frissítenie kell annak állapotát, vagy át kell migrálnia egy régebbi Microsoft Information Protection (MIP) munkafolyamat által írt címke‑metaadatot.

Az Aspose.Slides a modern érzékenységi címke metaadatokat a [Presentation.SensitivityLabels](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/sensitivitylabels/) segítségével teszi elérhetővé. Ez a tulajdonság egy [ISensitivityLabelCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabelcollection/) objektumot ad vissza, amelyet a prezentáció PPTX formátumban történő mentése előtt ellenőrizhet és módosíthat.

{{% alert color="info" title="Megjegyzés" %}}
Az érzékenységi címke azonosítókat és a szabályinformációkat a Microsoft Purview konfigurációja határozza meg. Ellenőrizze a címkék elérhetőségét és a szabálynak megfelelő követelményeket a környezetében, mielőtt metaadatokat adna hozzá vagy migrálna. A [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/contentmarktypes/) értékek a címkéhez kapcsolódó tartalmi jelöléseket írják le; önmagukban nem hoznak létre látható szöveget vagy alakzatot a diákon.
{{% /alert %}}

## **Érzékenységi címke tulajdonságainak megértése**

Minden [ISensitivityLabel](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/) a következő metaadatokat tartalmazza:

| Tulajdonság | Cél |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/id/) | Az érzékenységi címke azonosítása a Purview szabályban. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/siteid/) | Az oldal azonosítása, amely a címke szabályához tartozik. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/isenabled/) | Jelzi, hogy a címke engedélyezett‑e. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/isremoved/) | Jelzi, hogy a címke el lett távolítva. Állítsa ezt a tulajdonságot `true`‑ra, amikor a eltávolítási állapotot metaadatként kell megőrizni. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Megadja, hogy a címkét automatikusan vagy felhasználói döntés alapján alkalmazták. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Felsorolja a címkéhez kapcsolódó tartalomjelölés típusokat. |

A [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelassignmenttype/) felsorolás leírja, hogyan lett egy címke hozzárendelve:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelassignmenttype/) alapértelmezett vagy automatikusan alkalmazott címkét jelöl.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelassignmenttype/) felhasználói döntés alapján alkalmazott címkét jelöl, beleértve a kézzel alkalmazott, javasolt és kötelező címkéket.

A [SensitivityLabelContentType](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelcontenttype/) felsorolás azonosítja a címkéhez kapcsolódó jelölést:

| Érték | Jelentés |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelcontenttype/) | A címkét alapértelmezés szerint vagy automatikusan alkalmazták. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelcontenttype/) | A címke fejlécre vonatkozó tartalomjelölést tartalmaz. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelcontenttype/) | A címke láblécre vonatkozó tartalomjelölést tartalmaz. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelcontenttype/) | A címke vízjelre vonatkozó tartalomjelölést tartalmaz. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelcontenttype/) | A címke titkosítási védelmet tartalmaz. |

Több jelöléstípus is kapcsolható egy címkéhez.

## **Meglévő érzékenységi címkék listázása**

Olvassa be a modern címke gyűjteményt a [Presentation.SensitivityLabels](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/sensitivitylabels/) segítségével, és enumerálja azt. A következő példa felsorolja minden címkéhez tárolt tulajdonságot és tartalomjelölést:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **Érzékenységi címke hozzáadása tartalomjelöléssel**

Használja a [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabelcollection/add/) metódust a címke azonosítóval, oldal azonosítóval, engedélyezett állapottal és hozzárendelési móddal. Miután a metódus visszaadja az új [ISensitivityLabel](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/) objektumot, adja hozzá a szükséges jelölési értékeket a [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/contentmarktypes/) segítségével.

A következő példa manuálisan kiválasztott címkét ad hozzá, amely lábléc‑ és vízjel jelölésekkel rendelkezik, majd az eredményt PPTX formátumban menti:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **Érzékenységi címke frissítése**

Az [ISensitivityLabel](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/) tulajdonságai olvashatók és írhatók, kivéve a [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/contentmarktypes/) által visszaadott gyűjteményt, amelyet a lista műveletein keresztül módosítanak. A szükséges címke megtalálása után frissítheti annak azonosítóját, oldalazonosítóját, engedélyezett állapotát, hozzárendelési módját, eltávolítási állapotát és a tartalomjelölés típusait. Mentse a prezentációt a változások véglegesítéséhez.

A következő példa frissíti az első címke engedélyezett állapotát és hozzárendelési módját:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **Érzékenységi címke megjelölése eltávolítottként**

Az eltávolított címke állapotának megőrzéséhez keresse meg a címkét, és állítsa az [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/isremoved/) értékét `true`‑ra. Ez megőrzi a címke bejegyzését, miközben rögzíti az eltávolított állapotát. Ha helyette a modern gyűjteményből szeretne bejegyzést törölni, használja a [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabelcollection/removeat/) metódust; az összes bejegyzés törléséhez használja a [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabelcollection/clear/) metódust.

A következő példa egy adott címkét megjelöl eltávolítottként, és menti a frissített prezentációt:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **Régi MIP érzékenységi címkék olvasása és migrálása**

A régebbi MIP‑alapú munkafolyamatok a modern címkegyűjtemény helyett egyéni dokumentum tulajdonságokban tárolhatják az érzékenységi címke metaadatait. Olvassa be ezeket a metaadatokat a [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/getsensitivitylabels/) segítségével. A metódus feldolgozza a régi egyéni tulajdonságokat, és egy [ISensitivityLabel](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/) objektumokból álló tömböt ad vissza.

A metaadatok migrálásához adja hozzá az egyes visszakapott címkéket a modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabelcollection/) gyűjteményhez a [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabelcollection/add/) segítségével. Mivel egy már létező címkeazonosító hozzáadása kivételt vált ki, a példa ellenőrzi a célgyűjteményt, mielőtt minden címkét másolna. További ellenőrzéseket is beépíthet, hogy megerősítse, minden régi címke még létezik az aktuális Purview szabályban.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

A migráció a feldolgozott címkeobjektumokat a modern gyűjteménybe másolja. Nem szükséges az összes egyéni dokumentumtulajdonságot törölni, így a nem kapcsolódó dokumentum metaadatok érintetlenek maradnak. Használja az [IPresentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/save/) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) formátummal a modern címke metaadatok PPTX fájlba írásához.

## **GYIK**

**A tartalomjelölés típus hozzáadása látható fejlécet, láblécet vagy vízjelet hoz létre a diákon?**

Nem. A [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/contentmarktypes/) által hozzáadott értékek csak a címkéhez kapcsolódó jelöléseket írják le. Nem hoznak létre látható szöveget vagy alakzatot a prezentációban. Ha a munkafolyamatnak meg kell jelenítenie ezeket a jelöléseket, adja hozzá a megfelelő diatartalmat külön.

**Mi a különbség a címke eltávolítottként történő megjelölése és a gyűjteményből való törlése között?**

Az [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/isremoved/) `true`‑ra állítása megőrzi a címke bejegyzését és rögzíti az eltávolított állapotot. A [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabelcollection/removeat/) meghívása törli a bejegyzést a modern gyűjteményből. Válassza azt a műveletet, amely megfelel a szervezet metaadatmegőrzési követelményeinek.

**Tartalmazhat egy prezentáció egyszerre régi MIP metaadatokat és modern érzékenységi címkéket?**

Igen. A régi címkék megtarthatók az egyéni dokumentumtulajdonságokban, míg a modern címkék a [Presentation.SensitivityLabels](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/sensitivitylabels/) segítségével érhetők el. Használja a [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/getsensitivitylabels/) metódust a régi metaadatok beolvasásához, és csak azokat a valid címkéket migrálja, amelyek még nem szerepelnek a modern gyűjteményben.

**Mi történik, ha egy azonos azonosítóval rendelkező címkét többször hozzáadják?**

Az [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabelcollection/add/) `ArgumentException` kivételt dob, ha a gyűjtemény már tartalmaz egy azonos azonosítóval rendelkező címkét. Ellenőrizze a meglévő [ISensitivityLabel.Id](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/id/) értékeket, mielőtt címkéket adna hozzá vagy migrálná őket.

**Melyik kimeneti formátumot kell használni a frissített érzékenységi címkék megőrzéséhez?**

Mentse a prezentációt PPTX formátumban az [IPresentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/save/) metódus meghívásával a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) használatával, ahogy a fenti példákban látható.