---
title: Verwaltung von Präsentations-Kopf- und Fußzeilen in C++
linktitle: Kopf- und Fußzeile
type: docs
weight: 140
url: /de/cpp/presentation-header-and-footer/
keywords:
- Kopfzeile
- Kopfzeilentext
- Fußzeile
- Fußzeilentext
- Kopfzeile festlegen
- Fußzeile festlegen
- Handout
- Notizen
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für C++, um Kopf- und Fußzeilen in PowerPoint- und OpenDocument-Präsentationen hinzuzufügen und anzupassen, um ein professionelles Aussehen zu erzielen."
---

{{% alert color="primary" %}} 
[Aspose.Slides](/slides/de/cpp/) bietet Unterstützung für die Arbeit mit Kopf‑ und Fußzeilentexten von Folien, die tatsächlich auf der Folienmaster‑Ebene verwaltet werden.
{{% /alert %}} 

[Aspose.Slides for C++](/slides/de/cpp/) bietet die Möglichkeit, Kopf‑ und Fußzeilen in Präsentationsfolien zu verwalten. Diese werden tatsächlich auf der Präsentationsmaster‑Ebene verwaltet.
## **Kopf‑ und Fußzeilentext verwalten**
Notizen einer bestimmten Folie können wie im folgenden Beispiel aktualisiert werden:
``` cpp
// Funktion zum Setzen des Kopf-/Fußzeilentextes
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// Präsentation laden
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Fußzeile festlegen
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Header zugreifen und aktualisieren
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Präsentation speichern
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```


## **Kopf‑ und Fußzeilen in Handout‑ und Notizfolien verwalten**
Aspose.Slides for C++ unterstützt Kopf‑ und Fußzeilen in Handout‑ und Notizfolien. Bitte folgen Sie den nachstehenden Schritten:

- Laden Sie eine [Präsentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), die ein Video enthält.
- Ändern Sie die Einstellungen für Kopf‑ und Fußzeile für den Notizmaster und alle Notizfolien.
- Machen Sie den Master‑Notizfolien‑ und alle untergeordneten Fußzeilen‑Platzhalter sichtbar.
- Machen Sie den Master‑Notizfolien‑ und alle untergeordneten Datums‑ und Zeit‑Platzhalter sichtbar.
- Ändern Sie die Kopf‑ und Fußzeileneinstellungen nur für die erste Notizfolie.
- Machen Sie den Kopfzeilen‑Platzhalter der Notizfolie sichtbar.
- Setzen Sie den Text für den Kopfzeilen‑Platzhalter der Notizfolie.
- Setzen Sie den Text für den Datums‑Zeit‑Platzhalter der Notizfolie.
- Schreiben Sie die modifizierte Präsentationsdatei.

Code‑Snippet im nachstehenden Beispiel bereitgestellt.
``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Header- und Fußzeileneinstellungen für Notizen-Master und alle Notizfolien ändern
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// Master-Notizfolie und alle untergeordneten Footer-Platzhalter sichtbar machen
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// Master-Notizfolie und alle untergeordneten Header-Platzhalter sichtbar machen
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// Master-Notizfolie und alle untergeordneten Foliennummer-Platzhalter sichtbar machen
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// Master-Notizfolie und alle untergeordneten Datum‑und‑Uhrzeit-Platzhalter sichtbar machen
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// Text für Master-Notizfolie und alle untergeordneten Header-Platzhalter festlegen
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// Text für Master-Notizfolie und alle untergeordneten Footer-Platzhalter festlegen
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// Text für Master-Notizfolie und alle untergeordneten Datum‑und‑Uhrzeit-Platzhalter festlegen
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// Change Header and Footer settings for first notes slide only
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// Header-Platzhalter dieser Notizfolie sichtbar machen
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// Footer-Platzhalter dieser Notizfolie sichtbar machen
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// Foliennummer-Platzhalter dieser Notizfolie sichtbar machen
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// Datum‑Uhrzeit-Platzhalter dieser Notizfolie sichtbar machen
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// Text für Header-Platzhalter der Notizfolie festlegen
	headerFooterManager->SetHeaderText(u"New header text");
	// Text für Footer-Platzhalter der Notizfolie festlegen
	headerFooterManager->SetFooterText(u"New footer text");
	// Text für Datum‑Uhrzeit-Platzhalter der Notizfolie festlegen
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Kann ich einer normalen Folie einen „Kopfzeile“ hinzufügen?**

In PowerPoint gibt es „Kopfzeilen“ nur für Notizen und Handouts; auf normalen Folien sind die unterstützten Elemente Fußzeile, Datum/Uhrzeit und Foliennummer. In Aspose.Slides gilt dieselbe Einschränkung: Kopfzeile nur für Notizen/Handouts und auf Folien – Fußzeile/DatumUhrzeit/Foliennummer.

**Was, wenn das Layout keinen Fußzeilenbereich enthält – kann ich die Sichtbarkeit „aktivieren“?**

Ja. Prüfen Sie die Sichtbarkeit über den Kopf‑/Fußzeilen‑Manager und aktivieren Sie sie bei Bedarf. Diese API‑Indikatoren und -Methoden sind für Fälle vorgesehen, in denen der Platzhalter fehlt oder ausgeblendet ist.

**Wie kann ich die Foliennummerierung ab einem anderen Wert als 1 beginnen lassen?**

Setzen Sie die [erste Foliennummer](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) der Präsentation; danach wird die gesamte Nummerierung neu berechnet. Zum Beispiel können Sie bei 0 oder 10 beginnen und die Nummer auf der Titelfolie ausblenden.

**Was passiert mit Kopf‑ und Fußzeilen beim Exportieren zu PDF/Bildern/HTML?**

Sie werden als reguläre Textelemente der Präsentation gerendert. Das heißt, wenn die Elemente auf Folien/Notizseiten sichtbar sind, erscheinen sie auch im Ausgabedokument zusammen mit dem übrigen Inhalt.