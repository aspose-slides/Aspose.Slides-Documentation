---
title: Header Footer
type: docs
weight: 220
url: /de/cpp/examples/elements/header-footer/
keywords:
- Codebeispiel
- Kopfzeile
- Fußzeile
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Steuern Sie Folienkopfzeilen und -fußzeilen mit Aspose.Slides für C++: Fügen Sie Daten, Folienzahlen und benutzerdefinierten Text in PPT, PPTX und ODP mit C++-Beispielen hinzu."
---
Dieser Artikel zeigt, wie man Fußzeilen hinzufügt und Datums- und Zeitplatzhalter mit **Aspose.Slides for C++** aktualisiert.

## **Fußzeile hinzufügen**

Fügen Sie Text zum Fußzeilenbereich einer Folie hinzu und machen Sie ihn sichtbar.

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **Datum und Zeit aktualisieren**

Ändern Sie den Datums- und Zeitplatzhalter auf einer Folie.

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```