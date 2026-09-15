---
title: Tłumacz Prezentacji Napędzany AI
linktitle: Tłumacz Napędzany AI
type: docs
weight: 20
url: /pl/python-net/ai/translator/
keywords:
- tłumacz prezentacji AI
- tłumacz slajdów AI
- funkcja napędzana AI
- prezentacja wielojęzyczna
- slajd wielojęzyczny
- tłumaczenie prezentacji
- tłumaczenie slajdów
- funkcje oparte na AI
- możliwości AI
- agent AI
- klient internetowy
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Tłumacz slajdy PowerPoint za pomocą AI korzystając z Aspose.Slides dla Pythona. Lokalizuj pliki PPT, PPTX i ODP, zachowując układ — szybko i przyjazne dla programistów. Wypróbuj."
---
## **Wprowadzenie**

Aspose.Slides jest potężnym API do programowego zarządzania prezentacjami PowerPoint. oprócz tworzenia, edytowania i konwertowania slajdów, oferuje funkcje napędzane sztuczną inteligencją — takie jak [Presentation Translation API](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/) dla treści wielojęzycznych.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych możliwości AI, ale integruje się z zewnętrznymi modelami AI przez internet. Ta funkcjonalność jest udostępniana za pośrednictwem klasy [SlidesAIAgent](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/slidesaiagent/), która wykorzystuje podklasy [IAIWebClient](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/iaiwebclient/) do komunikacji z usługami AI.

Możesz użyć wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/openaiwebclient/), aby połączyć się z API OpenAI, lub zaimplementować własny [IAIWebClient](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/iaiwebclient/), aby korzystać z innego dostawcy AI lub modelu językowego.

Aspose.Slides obsługuje komunikację, analizuje odpowiedzi AI i inteligentnie wstawia przetłumaczoną zawartość, zachowując oryginalny układ i formatowanie slajdów.

{{% alert color="info" %}}
Uwaga: API OpenAI jest usługą płatną, więc będziesz musiał założyć konto i podać swój klucz API podczas korzystania z wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Przykład**

W tym przykładzie tłumaczymy prezentację PowerPoint na język japoński przy użyciu wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/openaiwebclient/) i określonego modelu OpenAI [model](https://platform.openai.com/docs/models).

```py
import aspose.slides as slides

# Załaduj prezentację do przetłumaczenia.
with slides.Presentation("sample.pptx") as presentation:

    # Utwórz klienta AI za pomocą OpenAIWebClient, podając swój model i klucz API.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # Zainicjalizuj SlidesAIAgent przy użyciu klienta AI.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Przetłumacz prezentację na język japoński.
        ai_agent.translate(presentation, "japanese")

        # Zapisz przetłumaczoną prezentację jako PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Przykład Azure OpenAI**

Od wersji **26.7.0** Aspose.Slides dla Pythona poprzez .NET obsługuje dostawców zgodnych z OpenAI, w tym Azure OpenAI. Możesz skonfigurować tłumacz, aby używał własnej instalacji Azure, korzystając z [OpenAICompatibleWebClient](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/openaicompatiblewebclient/).

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```

Ten fragment kodu pokazuje, jak przetłumaczyć prezentację przy użyciu Twojego punktu końcowego Azure OpenAI. Zastąp wartości zastępcze nazwą wdrożenia, kluczem API i adresem URL punktu końcowego.

## **Kluczowe korzyści**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/) oferuje rozwiązanie oparte na AI do dostarczania wielojęzycznych prezentacji PowerPoint. Automatyzując tłumaczenie przy zachowaniu układu i projektu, oszczędza czas i minimalizuje błędy w porównaniu z ręcznymi procesami. Niezależnie od tego, czy jesteś deweloperem, edukatorem, czy profesjonalistą biznesowym, to API umożliwia tworzenie angażujących, lokalizowanych prezentacji dla globalnej publiczności — zwiększając zasięg i poprawiając komunikację.