---
title: Recuperar e Atualizar Informações da Apresentação em C++
linktitle: Informações da Apresentação
type: docs
weight: 30
url: /pt/cpp/examine-presentation/
keywords:
- formato de apresentação
- propriedades da apresentação
- propriedades do documento
- obter propriedades
- ler propriedades
- alterar propriedades
- modificar propriedades
- atualizar propriedades
- examinar PPTX
- examinar PPT
- examinar ODP
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Explore slides, estrutura e metadados em apresentações PowerPoint e OpenDocument usando C++ para obter insights mais rápidos e auditorias de conteúdo mais inteligentes."
---
## **Visão geral**

Este artigo mostra como inspecionar informações de apresentação no Aspose.Slides. Ele explica como determinar o formato atual de uma apresentação sem carregar o arquivo completo, ler suas propriedades do documento e atualizar essas propriedades quando necessário.

Os exemplos são baseados nas APIs [PresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/documentproperties/) e demonstram operações típicas para trabalhar com metadados de apresentação.

## **Verificar o formato de uma apresentação**

Antes de trabalhar em uma apresentação, você pode querer descobrir em qual formato (PPT, PPTX, ODP e outros) a apresentação está no momento.

Você pode verificar o formato de uma apresentação sem carregá‑la. Veja este código C++:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Obter propriedades da apresentação**

Este código C++ mostra como obter as propriedades da apresentação (informações sobre a apresentação):

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ...
```

## **Atualizar propriedades da apresentação**

O Aspose.Slides fornece o método [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) que permite fazer alterações nas propriedades da apresentação.

Suponha que temos uma apresentação PowerPoint com as propriedades do documento mostradas abaixo.

![Propriedades originais do documento da apresentação PowerPoint](input_properties.png)

Este exemplo de código mostra como editar algumas propriedades da apresentação:

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Os resultados da alteração das propriedades do documento são mostrados abaixo.

![Propriedades alteradas do documento da apresentação PowerPoint](output_properties.png)

## **Links úteis**

Para obter mais informações sobre uma apresentação e seus atributos de segurança, você pode achar estes links úteis:

- [Verificando se uma apresentação está criptografada](https://docs.aspose.com/slides/pt/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Verificando se uma apresentação está protegida contra gravação (somente leitura)](https://docs.aspose.com/slides/pt/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Verificando se uma apresentação está protegida por senha antes de carregá‑la](https://docs.aspose.com/slides/pt/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmando a senha usada para proteger uma apresentação](https://docs.aspose.com/slides/pt/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Procure por informações de [fonte incorporada](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsmanager/getembeddedfonts/) no nível da apresentação e, em seguida, compare essas entradas com o conjunto de [fontes realmente usadas no conteúdo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsmanager/getfonts/) para identificar quais fontes são críticas para a renderização.

**Como posso rapidamente saber se o arquivo tem slides ocultos e quantos?**

Percorra a [coleção de slides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slidecollection/) e inspecione o [indicador de visibilidade](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slide/get_hidden/) de cada slide.

**Posso detectar se um tamanho e orientação de slide personalizados são usados e se diferem dos padrões?**

Sim. Compare o atual [tamanho e orientação do slide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_slidesize/) com as predefinições padrão; isso ajuda a antecipar o comportamento para impressão e exportação.

**Existe uma maneira rápida de ver se os gráficos referenciam fontes de dados externas?**

Sim. Percorra todos os [gráficos](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chart/), verifique sua [fonte de dados](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) e observe se os dados são internos ou baseados em link, incluindo quaisquer links quebrados.

**Como posso avaliar slides 'pesados' que podem desacelerar a renderização ou a exportação para PDF?**

Para cada slide, contabilize o número de objetos e procure por imagens grandes, transparência, sombras, animações e multimídia; atribua uma pontuação aproximada de complexidade para sinalizar possíveis pontos críticos de desempenho.