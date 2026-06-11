---
title: Tłumacz prezentacji oparty na AI
linktitle: Tłumacz oparty na AI
type: docs
weight: 20
url: /pl/python-net/ai/translator/
keywords:
- Tłumacz prezentacji AI
- Tłumacz slajdów AI
- Funkcja oparta na AI
- Prezentacja wielojęzyczna
- Slajd wielojęzyczny
- Tłumaczenie prezentacji
- Tłumaczenie slajdów
- Funkcje sterowane AI
- Możliwości AI
- Agent AI
- Klient internetowy
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Tłumacz slajdy PowerPoint przy użyciu AI z Aspose.Slides dla Pythona. Lokalizuj pliki PPT, PPTX i ODP, zachowując układ - szybko i przyjazne dla programistów. Wypróbuj."
---
## **Wprowadzenie**

Aspose.Slides jest potężnym interfejsem API umożliwiającym programistyczne zarządzanie prezentacjami PowerPoint. Oprócz tworzenia, edytowania i konwertowania slajdów, oferuje funkcje oparte na sztucznej inteligencji – takie jak [Presentation Translation API](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/) do wielojęzykowej zawartości slajdów.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych możliwości AI, ale integruje się z zewnętrznymi modelami AI przez Internet. Funkcjonalność ta jest udostępniana poprzez klasę [SlidesAIAgent](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/slidesaiagent/), która używa podklas [IAIWebClient](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/iaiwebclient/) do komunikacji z usługami AI.

Możesz użyć wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/openaiwebclient/), aby połączyć się z API OpenAI, lub zaimplementować własny [IAIWebClient](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/iaiwebclient/), aby korzystać z innego dostawcy AI lub modelu językowego.

Aspose.Slides obsługuje komunikację, parsuje odpowiedzi AI i inteligentnie wstawia przetłumaczoną treść, zachowując pierwotny układ i formatowanie slajdów.

{{% alert color="primary" %}}
Należy pamiętać, że API OpenAI jest usługą płatną, więc będziesz musiał utworzyć konto i podać swój klucz API podczas używania wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Przykład**

W tym przykładzie tłumaczymy prezentację PowerPoint na język japoński przy użyciu wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/openaiwebclient/) oraz określonego modelu OpenAI [model](https://platform.openai.com/docs/models).

```py
# Wczytaj prezentację do przetłumaczenia.
with slides.Presentation("sample.pptx") as presentation:

    # Utwórz klienta AI przy użyciu OpenAIWebClient, określając model i klucz API.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # Zainicjalizuj SlidesAIAgent przy użyciu klienta AI.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Przetłumacz prezentację na język japoński.
        ai_agent.translate(presentation, "japanese")

        # Zapisz przetłumaczoną prezentację jako PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

## **Kluczowe korzyści**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ai/) oferuje rozwiązanie oparte na AI umożliwiające dostarczanie wielojęzycznych prezentacji PowerPoint. Automatyzując tłumaczenie przy zachowaniu układu i projektu, oszczędza czas i minimalizuje błędy w porównaniu z ręcznymi procesami. Niezależnie od tego, czy jesteś programistą, edukatorem, czy profesjonalistą biznesowym, to API pozwala tworzyć angażujące, lokalizowane prezentacje dla odbiorców na całym świecie – zwiększając zasięg i poprawiając komunikację.