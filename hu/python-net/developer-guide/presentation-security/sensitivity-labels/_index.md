---
title: Érzékenységi címkék kezelése PowerPoint prezentációkban Python nyelven
linktitle: Érzékenységi címkék
type: docs
weight: 50
url: /hu/python-net/sensitivity-labels/
keywords:
- érzékenységi címke
- Microsoft Purview
- Microsoft Information Protection
- MIP metaadatok
- tartalomjelölés
- információvédelem
- dokumentum-irányítás
- PowerPoint
- PPTX
- prezentációbiztonság
- Python
- Aspose.Slides
description: "Olvassa, adja hozzá, frissítse, távolítsa el, és migrálja a Microsoft Purview érzékenységi címkéket PowerPoint PPTX prezentációkban az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

Microsoft Purview érzékenységi címkék segítik a szervezeteket a dokumentumok osztályozásában és kormányzásában. Az automatikus prezentációfeldolgozás során egy alkalmazásnak meg kell őriznie egy meglévő címkét, alkalmaznia kell egy politikával kiválasztott címkét, frissítenie kell annak állapotát, vagy át kell migrálnia a régebbi Microsoft Information Protection (MIP) munkafolyamat által írt címke metaadatokat.

Az Aspose.Slides for Python via .NET a modern érzékenységi címke metaadatokat teszi elérhetővé a [Presentation.sensitivity_labels](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/sensitivity_labels/). Ez a tulajdonság egy [SensitivityLabelCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelcollection/) objektumot ad vissza, amelyet a prezentáció PPTX‑ként való mentése előtt meg lehet vizsgálni és módosítani.

{{% alert color="primary" title="Megjegyzés" %}}
Az érzékenységi címke azonosítókat és a szabályzat információkat a Microsoft Purview beállításai határozzák meg. Ellenőrizze a címkék elérhetőségét és a szabályzat követelményeit a környezetében, mielőtt metaadatokat adna hozzá vagy migrálná őket. A [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabel/content_mark_types/) értékek leírják a címkéhez kapcsolódó tartalomjelöléseket; ezek önmagukban nem adnak hozzá látható szöveget vagy alakzatot a diákhoz.
{{% /alert %}}

## **Érzékenységi címke tulajdonságainak megértése**

Minden [SensitivityLabel](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabel/) a következő metaadatokat tartalmazza:

| Tulajdonság | Cél |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabel/id/) | Azonosítja az érzékenységi címkét a Purview szabályzatban. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabel/site_id/) | Azonosítja a címke szabályzathoz kapcsolódó helyet. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabel/is_enabled/) | Jeli, hogy a címke engedélyezve van-e. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabel/is_removed/) | Jeli, hogy a címkét eltávolították. Állítsa ezt a tulajdonságot `True`‑ra, ha az eltávolítás állapotát a metaadatokban meg kell őrizni. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | Megadja, hogy a címkét automatikusan vagy felhasználói döntés alapján alkalmazták. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | Felsorolja a címkéhez kapcsolódó tartalomjelölés típusokat. |

A [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelassignmenttype/) felsoroló típus leírja, hogyan lett egy címke hozzárendelve:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelassignmenttype/) alapértelmezett vagy automatikusan alkalmazott címkét jelöl.
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelassignmenttype/) felhasználói döntés alapján alkalmazott címkét jelöl, beleértve a manuálisan alkalmazott, ajánlott és kötelező címkéket.

A [SensitivityLabelContentType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelcontenttype/) felsoroló típus azonosítja a címkéhez kapcsolódó jelölést:

| Érték | Jelentés |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelcontenttype/) | A címkét alapértelmezés szerint vagy automatikusan alkalmazták. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelcontenttype/) | Fejléc tartalom jelölése kapcsolódik a címkéhez. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelcontenttype/) | Lábléc tartalom jelölése kapcsolódik a címkéhez. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelcontenttype/) | Vízjel tartalom jelölése kapcsolódik a címkéhez. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelcontenttype/) | Titkosítási védelem kapcsolódik a címkéhez. |

Több jelöléstípus is kapcsolódhat egy címkéhez.

## **Meglévő érzékenységi címkék listázása**

Olvassa be a modern címke gyűjteményt a [Presentation.sensitivity_labels](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/sensitivity_labels/) segítségével, és iterálja azt. Az alábbi példa minden egyes címkéhez tárolt tulajdonságot és tartalomjelölést listáz:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **Érzékenységi címke hozzáadása tartalomjelöléssel**

Használja a [SensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelcollection/add/) metódust a címke azonosítóval, a hely azonosítóval, az engedélyezett állapottal és a hozzárendelési móddal. A hely azonosítót Python `uuid.UUID` objektumként adja át. A metódus visszaadja az új [SensitivityLabel](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabel/), ezután fűzze hozzá a szükséges jelölési értékeket a [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabel/content_mark_types/) listához.

Az alábbi példa manuálisan kiválasztott címkét ad hozzá, amely lábléc és vízjel jelölésekkel van társítva, majd a végeredményt PPTX‑ként menti:

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Érzékenységi címke frissítése**

A [SensitivityLabel] tulajdonságok olvashatók és írhatók, kivéve a [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabel/content_mark_types/) által visszaadott listát, amelyet a lista műveletein keresztül kell módosítani. A szükséges címke megtalálása után frissítheti az azonosítóját, a hely azonosítóját, az engedélyezett állapotot, a hozzárendelési módot, az eltávolítási állapotot és a tartalomjelölés típusokat. A változtatások mentéséhez mentse a prezentációt.

Az alábbi példa frissíti az első címke engedélyezett állapotát és a hozzárendelési módot:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Érzékenységi címke megjelölése eltávolítottként**

Az eltávolítás tényének megőrzéséhez keresse meg a címkét és állítsa a [SensitivityLabel.is_removed](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabel/is_removed/) értékét `True`‑ra. Ez megtartja a címke bejegyzését miközben rögzíti az eltávolított állapotát. Ha ehelyett a modern gyűjteményből szeretne bejegyzést törölni, használja a [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); az összes bejegyzés törléséhez használja a [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelcollection/clear/) metódust.

Az alábbi példa egy konkrét címkét megjelöl eltávolítottként, és elmenti a frissített prezentációt:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Régi MIP érzékenységi címkék olvasása és migrálása**

Az régebbi MIP-alapú munkafolyamatok a címke metaadatokat egyéni dokumentumtulajdonságokban tárolhatják a modern címke gyűjtemény helyett. Olvassa be ezt a metaadatot a [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) segítségével. A metódus feldolgozza a régi egyéni tulajdonságokat és [SensitivityLabel](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabel/) objektumokat ad vissza.

A metaadatok migrálásához adja hozzá a visszakapott címkéket a modern [SensitivityLabelCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelcollection/) a [SensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelcollection/add/) segítségével. Mivel egy duplikált címke azonosító hozzáadása kivételt okoz, a példa ellenőrzi a célgyűjteményt, mielőtt minden címkét másolna. További ellenőrzést is beépíthet, hogy megerősítse, minden régi címke még létezik a jelenlegi Purview szabályzatban.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

A migráció a feldolgozott címkeobjektumokat a modern gyűjteménybe másolja. Nem szükséges az összes egyéni dokumentumtulajdonságot törölni, ezért a nem kapcsolódó dokumentum metaadatok érintetlenek maradnak. Használja a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) metódust a [SaveFormat.PPTX](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/saveformat/) értékkel, hogy a modern címke metaadatokat PPTX fájlba írja.

## **GYIK**

**Létrehoz-e egy tartalomjelölés típus látható fejlécet, láblécet vagy vízjelet a diákon?**

Nincs. A [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabel/content_mark_types/) által hozzáadott értékek leírják a címkéhez kapcsolódó jelöléseket. Nem hoznak létre látható szöveget vagy alakzatot a prezentációban. Ha a munkafolyamatnak meg kell jelenítenie ezeket a jelöléseket, a megfelelő dia tartalmat külön kell hozzáadni.

**Mi a különbség a címke eltávolítottként való megjelölése és a gyűjteményből történő törlése között?**

A [SensitivityLabel.is_removed](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabel/is_removed/) `True`‑ra állítása megőrzi a címke bejegyzését és rögzíti az eltávolított állapotot. A [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) hívása törli a bejegyzést a modern gyűjteményből. Válassza azt a műveletet, amely megfelel a szervezet metaadatmegőrzési követelményeinek.

**Tartalmazhat-e egy prezentáció egyszerre régi MIP metaadatot és modern érzékenységi címkéket?**

Igen. A régi címkék maradhatnak az egyéni dokumentumtulajdonságokban, míg a modern címkék a [Presentation.sensitivity_labels](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/sensitivity_labels/) segítségével érhetők el. Használja a [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) metódust a régi metaadatok olvasásához, és csak azokat a valid címkéket migrálja, amelyek még nincsenek jelen a modern gyűjteményben.

**Mi történik, ha egy azonosítóval rendelkező címkét többször hozzáadják?**

A [SensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabelcollection/add/) kivételt dob, ha a gyűjtemény már tartalmaz ugyanazzal az azonosítóval rendelkező címkét. A címkék hozzáadása vagy migrálása előtt ellenőrizze a meglévő [SensitivityLabel.id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sensitivitylabel/id/) értékeket.

**Melyik kimeneti formátumot kell használni a frissített érzékenységi címkék megőrzéséhez?**

Mentse a prezentációt PPTX formátumban a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) hívásával a [SaveFormat.PPTX](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/saveformat/) értékkel, ahogy a fenti példákban látható.