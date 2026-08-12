---
title: Érzékenységi címkék kezelése PowerPoint prezentációkban .NET környezetben
linktitle: Érzékenységi címkék
type: docs
weight: 50
url: /hu/net/sensitivity-labels/
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
- prezentációbiztonság
- .NET
- C#
- Aspose.Slides
description: "Olvassa, adja hozzá, frissítse, távolítsa el és migrálja a Microsoft Purview érzékenységi címkéket PowerPoint PPTX prezentációkban az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

A Microsoft Purview érzékenységi címkék segítik a szervezeteket a dokumentumok besorolásában és irányításában. Automatizált prezentációfeldolgozás során egy alkalmazásnak meg kell őriznie egy meglévő címkét, egy szabály által kiválasztott címkét kell alkalmaznia, frissítenie kell annak állapotát, vagy át kell migrálnia a régebbi Microsoft Information Protection (MIP) munkafolyamat által írt címke-metaadatokat.

Az Aspose.Slides a modern érzékenységi címke metaadatokat a [Presentation.SensitivityLabels](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/sensitivitylabels/) segítségével teszi elérhetővé. Ez a tulajdonság egy [ISensitivityLabelCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabelcollection/) objektumot ad vissza, amelyet a prezentáció PPTX‑ként való mentése előtt megtekinthet és módosíthat.

{{% alert color="primary" title="Note" %}}

Az érzékenységi címke azonosítókat és a szabályinformációkat a Microsoft Purview konfigurációja határozza meg. Ellenőrizze a címkék elérhetőségét és a szabálykövetelményeket a környezetében, mielőtt metaadatot adna hozzá vagy migrálna. A [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/contentmarktypes/) értékek leírják a címkéhez kapcsolódó tartalomjelöléseket; önmagukban nem adnak hozzá látható szöveget vagy alakzatot a diákhoz.

{{% /alert %}}

## **Az érzékenységi címke tulajdonságainak megértése**

Minden [ISensitivityLabel](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/) a következő metaadatokat tartalmazza:

| Tulajdonság | Leírás |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/id/) | Azonosítja az érzékenységi címkét a Purview szabályban. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/siteid/) | Azonosítja a címkeszabályhoz kapcsolódó webhelyet. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/isenabled/) | Jelzi, hogy a címke engedélyezve van-e. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/isremoved/) | Jelzi, hogy a címkét eltávolították. Állítsa ezt a tulajdonságot **true**‑ra, ha az eltávolítási állapotot meg kell őrizni a metaadatban. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Megadja, hogy a címkét automatikusan vagy felhasználói döntés alapján alkalmazták. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Felsorolja a címkéhez kapcsolódó tartalomjelölés típusokat. |

A [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelassignmenttype/) felsoroló típus leírja, hogyan került a címke hozzárendelésre:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelassignmenttype/) egy alapértelmezett vagy automatikusan alkalmazott címkét jelöl.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelassignmenttype/) felhasználói döntésből származó címkét jelöl, beleértve a manuálisan alkalmazott, javasolt és kötelező címkéket.

A [SensitivityLabelContentType](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelcontenttype/) felsoroló típus azonosítja a címkéhez tartozó jelölést:

| Érték | Jelentés |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelcontenttype/) | A címket alapértelmezés szerint vagy automatikusan alkalmazták. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelcontenttype/) | Fejléc tartalomjelölés kapcsolódik a címkéhez. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelcontenttype/) | Lábléc tartalomjelölés kapcsolódik a címkéhez. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelcontenttype/) | Vízjel tartalomjelölés kapcsolódik a címkéhez. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/hu/net/aspose.slides/sensitivitylabelcontenttype/) | Titkosítási védelem kapcsolódik a címkéhez. |

Több jelöléstípus is kapcsolódhat egy címkéhez.

## **Meglévő érzékenységi címkék felsorolása**

Olvassa be a modern címkegyűjteményt a [Presentation.SensitivityLabels](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/sensitivitylabels/) segítségével, és iterálja végig. Az alábbi példa minden címke összes tulajdonságát és tartalomjelölését listázza:

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

Használja a [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabelcollection/add/) metódust a címkeazonosító, webhelyazonosító, engedélyezett állapot és hozzárendelési mód megadásával. A metódus visszatér az új [ISensitivityLabel](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/) példánnyal, amelyhez a szükséges jelölésértékeket a [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/contentmarktypes/) segítségével adhatja hozzá.

Az alábbi példa egy manuálisan kiválasztott címkét ad hozzá, amelyhez lábléc és vízjel jelölések vannak társítva, majd PPTX‑ként menti az eredményt:

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

Az [ISensitivityLabel](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/) tulajdonságai olvashatóak és írhatóak, kivéve a [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/contentmarktypes/) által visszaadott gyűjteményt, amelyet a lista műveletein keresztül módosíthat. A szükséges címke megtalálása után frissítheti azonosítóját, webhelyazonosítóját, engedélyezett állapotát, hozzárendelési módját, eltávolítási állapotát és a tartalomjelölés típusait. Mentse a prezentációt a változások rögzítéséhez.

Az alábbi példa az első címke engedélyezett állapotát és hozzárendelési módját frissíti:

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

## **Címke megjelölése eltávolítottként**

Az eltávolítás tényének megőrzéséhez keresse meg a címkét, és állítsa a [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/isremoved/) értékét **true**‑ra. Ezzel a címke bejegyzése megmarad, de eltávolított állapotot rögzít. Ha a modern gyűjteményből valóban törölni szeretne egy bejegyzést, használja a [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabelcollection/removeat/) metódust; a [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabelcollection/clear/) a teljes gyűjtemény kiürítéséhez.

Az alábbi példa egy adott címkét eltávolítottként jelöl, majd menti a frissített prezentációt:

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

A régebbi MIP‑alapú munkafolyamatok az érzékenységi címke metaadatokat egyéni dokumentumtulajdonságokban tárolhatják a modern címkegyűjtemény helyett. Olvassa be ezeket a metaadatokat a [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/getsensitivitylabels/) segítségével. A metódus feldolgozza a régi egyéni tulajdonságokat, és egy [ISensitivityLabel](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/) objektumok tömbjét adja vissza.

A metaadat migrálásához adja hozzá a visszakapott címkéket a modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabelcollection/) gyűjteményhez a [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabelcollection/add/) metódussal. Mivel egy már létező címkeazonosító hozzáadása kivételt vált ki, a példa a célgyűjteményt ellenőrzi, mielőtt minden címkét átmásolna. További ellenőrzésekkel megerősítheti, hogy minden régi címke még jelen van az aktuális Purview szabályban.

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

A migráció a feldolgozott címkeobjektumokat a modern gyűjteménybe másolja. Nem szükséges az összes egyéni dokumentumtulajdonságot törölni, így a nem kapcsolódó dokumentum-metaadatok érintetlenek maradnak. A modern címke metaadatok PPTX fájlba írásához használja az [IPresentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/save/) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) paraméterrel.

## **GYIK**

**A tartalomjelölés típus hozzáadása látható fejlécet, láblécet vagy vízjelet hoz létre a diákon?**

Nem. A [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/contentmarktypes/) által hozzáadott értékek leírják a címkéhez kapcsolódó jelöléseket. Nem hoznak létre látható szöveget vagy alakzatot a prezentációban. Az érintett diatartalmat külön kell hozzáadni, ha a munkafolyamatnak meg kell jelenítenie ezeket a jelöléseket.

**Mi a különbség a címke eltávolítottként való megjelölése és a gyűjteményből való törlése között?**

A [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/isremoved/) **true**‑ra állítása megtartja a címke bejegyzését és rögzíti annak eltávolított állapotát. A [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabelcollection/removeat/) meghívása törli a bejegyzést a modern gyűjteményből. Válassza azt a műveletet, amely megfelel a szervezet metaadat-megőrzési követelményeinek.

**Lehet egy prezentációban egyszerre régi MIP metaadat és modern érzékenységi címke is?**

Igen. A régi címkék maradhatnak az egyéni dokumentumtulajdonságokban, míg a modern címkék a [Presentation.SensitivityLabels](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/sensitivitylabels/) segítségével érhetők el. Használja a [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/getsensitivitylabels/) metódust a régi metaadatok beolvasásához, és csak a már nem létező címkéket migrálja a modern gyűjteménybe.

**Mi történik, ha egy azonosítóval már meglévő címkét többször próbálunk hozzáadni?**

A [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabelcollection/add/) `ArgumentException`‑t dob, ha a gyűjtemény már tartalmaz egy azonosítóval megegyező címkét. Ellenőrizze a meglévő [ISensitivityLabel.Id](https://reference.aspose.com/slides/hu/net/aspose.slides/isensitivitylabel/id/) értékeket, mielőtt címkéket adna hozzá vagy migrálna.

**Milyen kimeneti formátumot kell használni a frissített érzékenységi címkék megőrzéséhez?**

Mentse a prezentációt PPTX formátumban az [IPresentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/save/) metódus hívásával, a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) paraméterrel, ahogy a fenti példákban is látható.