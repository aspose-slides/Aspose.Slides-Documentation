---
title: Generator wielojęzycznych slajdów zasilany AI
linktitle: Generator zasilany AI
type: docs
weight: 40
url: /pl/python-net/ai/generator/
keywords:
- prezentacja wielojęzyczna
- slajd wielojęzyczny
- generator prezentacji AI
- generator slajdów AI
- funkcja zasilana AI
- agent AI
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Generuj wielojęzyczne slajdy z tekstu przy użyciu Aspose.Slides dla Pythona. Zastosuj swój szablon i wyeksportuj dopracowane zestawy do PowerPoint i OpenDocument. Dowiedz się więcej."
---
## **Wprowadzenie**

Aspose.Slides wprowadza nową funkcję opartą na sztucznej inteligencji, Generator Prezentacji, która umożliwia programistom automatyczne tworzenie dobrze zorganizowanych prezentacji PowerPoint na podstawie prostych danych tekstowych, takich jak opisy tematów, podsumowania, cytaty lub wypunktowania.

Użytkownicy mogą dostosować poziom szczegółowości treści oraz opcjonalnie zastosować własny szablon prezentacji, aby określić projekt wizualny.

Obecnie Generator Prezentacji AI strukturyzuje treść przy użyciu bloków tekstowych, list wypunktowanych i tabel. Generowanie obrazów nie jest jeszcze obsługiwane; jednak obrazy można łatwo dodać później przy użyciu narzędzi Aspose.Slides lub ręcznie.

Wynikiem jest pełna prezentacja PowerPoint, którą można używać bez zmian lub wyeksportować do dowolnego formatu obsługiwanego przez API Aspose.Slides. Chociaż generator dostarcza wyniki wysokiej jakości, może być konieczna drobna edycja końcowa, aby spełnić określone wymagania.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych modeli AI; zamiast tego integruje się z zewnętrznymi usługami AI przez internet. Integracja ta jest obsługiwana przez klasę [SlidesAIAgent](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/slidesaiagent/), która korzysta z implementacji klasy [IAIWebClient](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/iaiwebclient/) do komunikacji z modelem AI.

Można użyć wbudowanej klasy [OpenAIWebClient](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/openaiwebclient/), która łączy się z API OpenAI, lub dostarczyć własną implementację [IAIWebClient](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/iaiwebclient/) w celu współpracy z innym dostawcą AI lub modelem językowym. Aspose.Slides zarządza całą komunikacją z usługą AI i przetwarza odpowiedzi AI w celu generowania slajdów. Należy zauważyć, że API OpenAI jest usługą płatną, więc przy użyciu wbudowanej [OpenAIWebClient](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/openaiwebclient/) wymagane są konto i klucz API.

## **Zacznijmy kodować**

### **Przykład 1**

Ten przykład pokazuje, jak wygenerować prezentację na temat Aspose.Slides przy użyciu wbudowanej klasy [OpenAIWebClient](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/openaiwebclient/).

```py
# Utwórz instancję OpenAIWebClient, wbudowanej implementacji klienta sieciowego OpenAI.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

    # Utwórz instancję SlidesAIAgent, który zapewnia dostęp do funkcji zasilanych AI.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Zdefiniuj instrukcję generowania prezentacji.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Wygeneruj prezentację o średniej ilości treści na podstawie instrukcji.
    with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.MEDIUM) as presentation:

        # Zapisz wygenerowaną prezentację na dysku lokalnym jako plik PowerPoint (.pptx) file.
        presentation.save("Aspose.Slides.NET.pptx", slides.export.SaveFormat.PPTX)
```

### **Przykład 2**

Poniższy przykład demonstruje przeciążenia metody [generate_presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/slidesaiagent/generate_presentation/#str-asposeslidesaipresentationcontentamounttype-asposeslidesipresentation). W tym przypadku używana jest `master presentation` użytkownika.

```py
# Przekaż HttpClient do konstruktora OpenAIWebClient.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId") as ai_web_client:

    # Utwórz instancję SlidesAIAgent.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Zdefiniuj instrukcję generowania prezentacji.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Załaduj prezentację master z dysku lokalnego, aby użyć jako szablon projektu.
    with slides.Presentation("masterPresentation.pptx") as masterPresentation:

        # Wygeneruj szczegółową prezentację wykorzystując instrukcję i szablon master.
        with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.DETAILED, masterPresentation) as presentation:

            # Zapisz wygenerowaną prezentację jako PDF.
            presentation.save("Aspose.Slides.NET.pdf", slides.export.SaveFormat.PDF)
```

## **Kluczowe korzyści**

Nowy Generator Prezentacji AI w Aspose.Slides zapewnia szybki i elastyczny sposób tworzenia ustrukturyzowanych zestawów slajdów na podstawie prostych zapytań tekstowych. Dzięki obsłudze własnych szablonów może być bezproblemowo integrowany w szerokim zakresie aplikacji.

Typowe przypadki użycia obejmują tworzenie prezentacji marketingowych, materiałów edukacyjnych, raportów dla klientów oraz wewnętrznych zestawów slajdów. Chociaż generowanie obrazów nie jest jeszcze obsługiwane, narzędzie już teraz oferuje solidne podstawy do automatyzacji tworzenia prezentacji, a w przyszłości planowane są dalsze udoskonalenia.