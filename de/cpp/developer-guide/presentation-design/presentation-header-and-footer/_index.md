---
title: Präsentationskopf und -fußzeile
type: docs
weight: 140
url: /de/cpp/presentation-header-and-footer/
keywords: "Kopf- und Fußzeile in PowerPoint"
description: "Kopf- und Fußzeile in PowerPoint mit Aspose.Slides."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/de/cpp/) bietet Unterstützung für die Arbeit mit Texten in Kopf- und Fußzeilen, die tatsächlich auf der Ebene des Folienmeisters verwaltet werden.

{{% /alert %}} 

[Aspose.Slides für C++](/slides/de/cpp/) bietet die Funktion zur Verwaltung von Kopf- und Fußzeilen innerhalb von Präsentationsfolien. Diese werden tatsächlich auf der Ebene des Präsentationsmasters verwaltet.
## **Kopf- und Fußzeilentext verwalten**
Notizen bestimmter Folien können wie im folgenden Beispiel shown aktualisiert werden:

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

// Fußzeile setzen
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Kopfzeile zugreifen und aktualisieren
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Präsentation speichern
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **Kopf- und Fußzeilen in Handouts und Notizenfolien verwalten**
Aspose.Slides für C++ unterstützt Kopf- und Fußzeilen in Handouts und Notizenfolien. Bitte befolgen Sie die folgenden Schritte:

- Laden Sie eine [Präsentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), die ein Video enthält.
- Ändern Sie die Kopf- und Fußzeileneinstellungen für den Notizenmaster und alle Notizenfolien.
- Machen Sie die Kopfzeile des Master-Notizenblatts und alle Kind-Fußzeilenplatzhalter sichtbar.
- Machen Sie die Kopfzeile des Master-Notizenblatts und alle Kind-Datum- und Uhrzeitplatzhalter sichtbar.
- Ändern Sie die Kopf- und Fußzeileneinstellungen nur für die erste Notizenfolie.
- Machen Sie den Kopfzeilenplatzhalter der Notizenfolie sichtbar.
- Setzen Sie den Text für den Kopfzeilenplatzhalter der Notizenfolie.
- Setzen Sie den Text für den Datum-Uhrzeit-Platzhalter der Notizenfolie.
- Schreiben Sie die modifizierte Präsentationsdatei.

Der im folgenden Beispiel angegebene Codeausschnitt.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Ändern Sie die Kopf- und Fußzeileneinstellungen für den Notizenmaster und alle Notizenfolien
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// Machen Sie die Kopfzeile des Master-Notizenblatts und alle Kind-Fußzeilenplatzhalter sichtbar
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// Machen Sie die Kopfzeile des Master-Notizenblatts und alle Kind-Kopfzeilenplatzhalter sichtbar
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// Machen Sie die Kopfzeile des Master-Notizenblatts und alle Kind-Foliennummerplatzhalter sichtbar
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// Machen Sie die Kopfzeile des Master-Notizenblatts und alle Kind-Datum- und Uhrzeitplatzhalter sichtbar
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// Setzen Sie den Text für das Kopfzeilenplatzhalter des Master-Notizenblatts und alle Kind-Kopfzeilenplatzhalter
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// Setzen Sie den Text für das Fußzeilenplatzhalter des Master-Notizenblatts und alle Kind-Fußzeilenplatzhalter
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// Setzen Sie den Text für das Datum- und Uhrzeitplatzhalter des Master-Notizenblatts und alle Kind-Datum- und Uhrzeitplatzhalter
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// Ändern Sie die Kopf- und Fußzeileneinstellungen nur für die erste Notizenfolie
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// Machen Sie diesen Notizenfolienkopfzeilenplatzhalter sichtbar
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// Machen Sie diesen Notizenfußzeilenplatzhalter sichtbar
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// Machen Sie diesen Notizenfoliennummerplatzhalter sichtbar
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// Machen Sie diesen Notizenfolien-Datum- und Uhrzeitplatzhalter sichtbar
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// Setzen Sie den Text für den Kopfzeilenplatzhalter der Notizenfolie
	headerFooterManager->SetHeaderText(u"New header text");
	// Setzen Sie den Text für den Fußzeilenplatzhalter der Notizenfolie
	headerFooterManager->SetFooterText(u"New footer text");
	// Setzen Sie den Text für den Datum- und Uhrzeitplatzhalter der Notizenfolie
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```