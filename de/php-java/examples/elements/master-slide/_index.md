---
title: Masterfolie
type: docs
weight: 30
url: /de/php-java/examples/elements/master-slide/
keywords:
- Masterfolie
- Masterfolie hinzufügen
- Auf Masterfolie zugreifen
- Masterfolie entfernen
- Unbenutzte Masterfolie
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie Masterfolien in PHP mit Aspose.Slides: Erstellen, Bearbeiten, Klonen und Formatieren von Themes, Hintergründen, Platzhaltern, um Folien in PowerPoint und OpenDocument zu vereinheitlichen."
---
Masterfolien bilden die oberste Ebene der Folienvererbungshierarchie in PowerPoint. Eine **Masterfolie** definiert gemeinsame Designelemente wie Hintergründe, Logos und Textformatierung. **Layoutfolien** erben von Masterfolien, und **Normale Folien** erben von Layoutfolien.

Dieser Artikel zeigt, wie man Masterfolien mit Aspose.Slides für PHP via Java erstellt, ändert und verwaltet.

## **Masterfolie hinzufügen**

Dieses Beispiel zeigt, wie man eine neue Masterfolie erstellt, indem man die Standardfolie klont.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // Standard‑Masterfolie klonen.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tipp 1:** Masterfolien bieten eine Möglichkeit, ein konsistentes Branding oder gemeinsam genutzte Designelemente über alle Folien hinweg anzuwenden. Alle Änderungen an der Masterfolie werden automatisch auf abhängige Layout‑ und Normale Folien übertragen.

> 💡 **Tipp 2:** Alle Formen oder Formatierungen, die einer Masterfolie hinzugefügt werden, werden von Layoutfolien geerbt und wiederum von allen normalen Folien, die diese Layouts verwenden.  
> Das Bild unten veranschaulicht, wie ein auf einer Masterfolie hinzugefügtes Textfeld automatisch auf der endgültigen Folie dargestellt wird.

![Beispiel für Mastervererbung](master-slide-banner.png)

## **Zugriff auf eine Masterfolie**

Sie können auf Masterfolien über die Methode `Presentation::getMasters` zugreifen. So rufen Sie sie ab und arbeiten mit ihnen:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Auf die erste Masterfolie zugreifen.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Masterfolie entfernen**

Masterfolien können entweder nach Index oder per Referenz entfernt werden.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Nach Index entfernen.
        $presentation->getMasters()->removeAt(0);

        // Oder nach Referenz entfernen.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Unbenutzte Masterfolien entfernen**

Einige Präsentationen enthalten Masterfolien, die nicht verwendet werden. Das Entfernen dieser Folien kann helfen, die Dateigröße zu reduzieren.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Alle nicht verwendeten Masterfolien entfernen (auch solche, die als Beibehalten markiert sind).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Tipp:** Verwenden Sie `removeUnused(true)`, um unbenutzte Masterfolien zu bereinigen und die Präsentationsgröße zu minimieren.