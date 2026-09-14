---
title: Érzékenységi címkék kezelése PowerPoint prezentációkban Python nyelven
linktitle: Érzékenységi címkék
type: docs
weight: 50
url: /hu/python-java/sensitivity-labels/
keywords:
- érzékenységi címke
- Microsoft Purview
- Microsoft Information Protection
- MIP metaadat
- tartalomjelzés
- információvédelem
- dokumentumirányítás
- PowerPoint
- PPTX
- prezentációbiztonság
- Python
- Aspose.Slides
description: "Olvassa, adja hozzá, frissítse, távolítsa el és migrálja a Microsoft Purview érzékenységi címkéket PowerPoint PPTX prezentációkban az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

A Microsoft Purview érzékenységi címkék segítik a szervezeteket a dokumentumok osztályozásában és kormányzásában. Automatizált prezentációfeldolgozás során egy alkalmazásnak meg kell őriznie egy meglévő címkét, alkalmaznia kell egy szabály által kiválasztott címkét, frissítenie kell annak állapotát, vagy migrálni kell a régebbi Microsoft Information Protection (MIP) munkafolyamat által írt címke metaadatokat.

Aspose.Slides a modern érzékenységi címke metaadatokat a [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSensitivityLabels) segítségével teszi elérhetővé. Ez a metódus egy [SensitivityLabelCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelcollection/) objektumot ad vissza, amelyet ellenőrizhet és módosíthat, mielőtt a prezentációt PPTX formátumban menti.

{{% alert color="info" title="Note" %}}
Az érzékenységi címke azonosítókat és a szabályzati információkat a Microsoft Purview konfigurációja határozza meg. Ellenőrizze a címkék elérhetőségét és a szabályzat követelményeit a környezetében, mielőtt metaadatokat adna hozzá vagy migrálna. A [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) értékek a címkéhez kapcsolódó tartalomjelzéseket írják le; önmagukban nem adnak hozzá látható szöveget vagy alakzatot a diákhoz.
{{% /alert %}}

## **Érzékenységi címke tulajdonságainak megértése**

Minden [SensitivityLabel](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/) a következő metaadatokat tartalmazza:

| Módszerek | Cél |
| --- | --- |
| [getId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#getId) and [setId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#setId) | Az érzékenységi címke azonosítójának lekérése vagy beállítása a Purview szabályzatban. |
| [getSiteId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#getSiteId) and [setSiteId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#setSiteId) | Az címke szabályzathoz kapcsolódó hely (site) lekérése vagy beállítása. |
| [isEnabled](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#isEnabled) and [setEnabled](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#setEnabled) | Címke engedélyezett állapotának lekérése vagy beállítása. |
| [isRemoved](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#isRemoved) and [setRemoved](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#setRemoved) | Címke eltávolított állapotának lekérése vagy beállítása. Állítsa `True`‑ra, ha a eltávolítási állapotot meg kell őrizni a metaadatokban. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) and [setAssignmentMethodType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Címke automatikus vagy felhasználói döntés alapján történő alkalmazásának lekérése vagy beállítása. |
| [getContentMarkTypes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Címkéhez kapcsolódó tartalomjelzés típusok lekérése. |

A [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelassignmenttype/) osztály meghatározza, hogy a címkét hogyan rendelték hozzá:

- [Standard](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelassignmenttype/) egy alapértelmezett vagy automatikusan alkalmazott címkét jelöl.
- [Privileged](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelassignmenttype/) egy felhasználói döntés alapján alkalmazott címkét jelöl, beleértve a kézzel alkalmazott, ajánlott és kötelező címkéket.

A [SensitivityLabelContentType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelcontenttype/) osztály határozza meg a címkéhez kapcsolódó jelzést:

| Érték | Jelentés |
| --- | --- |
| [None](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelcontenttype/) | A címke alapértelmezés szerint vagy automatikusan lett alkalmazva. |
| [Header](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelcontenttype/) | Fejléc tartalomjelzés kapcsolódik a címkéhez. |
| [Footer](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelcontenttype/) | Lábjegyzet tartalomjelzés kapcsolódik a címkéhez. |
| [Watermark](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelcontenttype/) | Vízjel tartalomjelzés kapcsolódik a címkéhez. |
| [Encryption](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelcontenttype/) | Titkosítási védelem kapcsolódik a címkéhez. |

Több jelzéstípus is kapcsolható egyetlen címkéhez.

## **Meglévő érzékenységi címkék listázása**

Olvassa be a modern címke gyűjteményt a [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSensitivityLabels) segítségével, és sorolja fel. Az alábbi példa minden tulajdonságot és a címkékhez tárolt tartalomjelzést listáz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **Érzékenységi címke hozzáadása tartalomjelzéssel**

A [SensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelcollection/#add) metódust használja a címkeazonosítóval, a helyazonosítóval, az engedélyezett állapottal és az hozzárendelési módszerrel. Miután a metódus visszaadja az új [SensitivityLabel](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/) objektumot, adja hozzá a szükséges jelzési értékeket a [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) által visszaadott listán keresztül.

Az alábbi példa manuálisan kiválasztott címkét ad hozzá, amely lábjegyzet és vízjel jelzéssel rendelkezik, majd PPTX formátumban menti az eredményt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Érzékenységi címke frissítése**

A [SensitivityLabel](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/) értékek olvashatók/írhatók, kivéve, hogy a [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) által visszaadott listát a lista műveleteken keresztül módosítjuk. A szükséges címke megtalálása után frissítheti annak azonosítóját, helyazonosítóját, engedélyezett állapotát, hozzárendelési módját, eltávolítási állapotát és a tartalomjelzési típusokat. Mentse el a prezentációt a változások rögzítéséhez.

Az alábbi példa frissíti az első címke engedélyezett állapotát és hozzárendelési módját:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Érzékenységi címke megjelölése eltávolítottként**

Az eltávolított címke tényének megőrzéséhez találja meg a címkét, és hívja a [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#setRemoved) metódust `True` értékkel. Ez megőrzi a címke bejegyzést, miközben rögzíti az eltávolított állapotát. Ha ehelyett egy bejegyzést szeretne törölni a modern gyűjteményből, használja a [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) metódust; a [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelcollection/#clear) segítségével törölheti az összes bejegyzést.

Az alábbi példa egy adott címkét megjelöl eltávolítottként, és elmenti a frissített prezentációt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Örökölt MIP érzékenységi címkék olvasása és migrálása**

A régebbi, MIP-alapú munkafolyamatok a modern címke gyűjtemény helyett egyéni dokumentumtulajdonságokban tárolhatják az érzékenységi címke metaadatait. Olvassa be ezeket a metaadatokat a [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getSensitivityLabels) segítségével. A metódus feldolgozza az örökölt egyéni tulajdonságokat, és egy [SensitivityLabel](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/) objektumok tömbjét adja vissza.

A metaadatok migrálásához adja hozzá az egyes visszakapott címkéket a modern [SensitivityLabelCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelcollection/) gyűjteményhez a [SensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelcollection/#add) segítségével. Mivel egy ismétlődő címkeazonosító hozzáadása kivételt vált ki, a példa a másolás előtt ellenőrzi a célgyűjteményt. További validációt is beépíthet, hogy megerősítse, minden örökölt címke még létezik a jelenlegi Purview szabályzatban.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A migráció átmásolja a feldolgozott címke objektumokat a modern gyűjteménybe. Nem szükséges az összes egyéni dokumentumtulajdonság törlése, így a nem kapcsolódó dokumentum metaadatok érintetlenek maradnak. Használja a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) paraméterrel, hogy a modern címke metaadatokat PPTX fájlba írja.

## **GYIK**

**A tartalomjelzés típus hozzáadása látható fejlécet, lábjegyet vagy vízjelet hoz létre a diákon?**

Nincs. A [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) által visszaadott listához hozzáadott értékek csak a címkéhez kapcsolódó jelzéseket írják le. Nem hoznak létre látható szöveget vagy alakzatot a prezentációban. Ha a munkafolyamatnak meg kell jelenítenie ezeket a jelzéseket, adja hozzá a megfelelő diatartalmat külön.

**Mi a különbség egy címke eltávolítottként való megjelölése és a gyűjteményből való törlése között?**

A [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#setRemoved) `True` értékkel történő hívása megtartja a címke bejegyzést és rögzíti az eltávolított állapotát. A [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) hívása törli a bejegyzést a modern gyűjteményből. Válassza azt a műveletet, amely megfelel a szervezet metaadatmegőrzési követelményeinek.

**Lehet egy prezentációban egyszerre örökölt MIP metaadat és modern érzékenységi címke is?**

Igen. Az örökölt címkék maradhatnak az egyéni dokumentumtulajdonságokban, míg a modern címkék a [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSensitivityLabels) segítségével érhetők el. Használja a [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getSensitivityLabels) metódust az örökölt metaadatok beolvasásához, és migrálja csak azokat a címkéket, amelyek még nem szerepelnek a modern gyűjteményben.

**Mi történik, ha egy azonosítóval rendelkező címkét többször adják hozzá?**

A [SensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabelcollection/#add) kivételt dob, ha a gyűjtemény már tartalmaz egy ugyanazzal az azonosítóval rendelkező címkét. A címkék hozzáadása vagy migrálása előtt ellenőrizze a [SensitivityLabel.getId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sensitivitylabel/#getId) által visszaadott meglévő értékeket.

**Melyik kimeneti formátumot kell használni a frissített érzékenységi címkék megőrzéséhez?**

Mentse a prezentációt PPTX formátumban a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) paraméterrel, ahogyan a fenti példákban látható.