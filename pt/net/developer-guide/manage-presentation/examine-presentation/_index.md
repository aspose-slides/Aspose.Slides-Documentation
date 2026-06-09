---
title: Recuperar e Atualizar Informações de Apresentação em .NET
linktitle: Informações da Apresentação
type: docs
weight: 30
url: /pt/net/examine-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Explore slides, estrutura e metadados em apresentações PowerPoint e OpenDocument usando .NET para obter insights mais rápidos e auditorias de conteúdo mais inteligentes."
---
## **Visão Geral**

Este artigo mostra como inspecionar informações de apresentação no Aspose.Slides. Ele explica como determinar o formato atual de uma apresentação sem carregar o arquivo completo, ler suas propriedades de documento e atualizar essas propriedades quando necessário.

Os exemplos são baseados nas APIs [PresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/documentproperties/) e demonstram operações típicas para trabalhar com metadados de apresentação.

## **Verificar o Formato de uma Apresentação**

Antes de trabalhar em uma apresentação, você pode desejar descobrir em qual formato (PPT, PPTX, ODP e outros) a apresentação está no momento.

Você pode verificar o formato de uma apresentação sem carregá‑la. Veja este código C#:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Obter Propriedades da Apresentação**

Este código C# mostra como obter as propriedades da apresentação (informações sobre a apresentação):

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

Você pode querer ver as [propriedades na classe DocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/documentproperties/#properties).

## **Atualizar Propriedades da Apresentação**

O Aspose.Slides fornece o método [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) que permite fazer alterações nas propriedades da apresentação.

Suponha que tenhamos uma apresentação PowerPoint com as propriedades de documento mostradas abaixo.

![Propriedades originais do documento da apresentação PowerPoint](input_properties.png)

Este exemplo de código mostra como editar algumas propriedades da apresentação:

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Os resultados da alteração das propriedades do documento são mostrados abaixo.

![Propriedades alteradas do documento da apresentação PowerPoint](output_properties.png)

## **Links Úteis**

Para obter mais informações sobre uma apresentação e seus atributos de segurança, você pode achar estes links úteis:

- [Verificando se uma Apresentação está Criptografada](https://docs.aspose.com/slides/pt/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Verificando se uma Apresentação está Protegida contra Escrita (somente leitura)](https://docs.aspose.com/slides/pt/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Verificando se uma Apresentação está Protegida por Senha Antes de Carregá‑la](https://docs.aspose.com/slides/pt/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmando a Senha Usada para Proteger uma Apresentação](https://docs.aspose.com/slides/pt/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Perguntas Frequentes**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Procure por [informações de fontes incorporadas](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/getembeddedfonts/) no nível da apresentação, depois compare essas entradas com o conjunto de [fonts realmente usadas no conteúdo](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/getfonts/) para identificar quais fontes são críticas para a renderização.

**Como posso descobrir rapidamente se o arquivo tem slides ocultos e quantos?**

Itere através da [coleção de slides](https://reference.aspose.com/slides/pt/net/aspose.slides/slidecollection/) e inspeccione o [indicador de visibilidade](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/hidden/) de cada slide.

**Posso detectar se um tamanho e orientação de slide personalizados são usados e se diferem dos padrões?**

Sim. Compare o [tamanho de slide](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/slidesize/) e a orientação atuais com as predefinições padrão; isso ajuda a prever o comportamento ao imprimir e exportar.

**Existe uma maneira rápida de ver se os gráficos referenciam fontes de dados externas?**

Sim. Percorra todos os [gráficos](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chart/), verifique sua [fonte de dados](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartdata/datasourcetype/), e observe se os dados são internos ou baseados em links, incluindo quaisquer links quebrados.

**Como posso avaliar slides 'pesados' que podem retardar a renderização ou a exportação para PDF?**

Para cada slide, contabilize a quantidade de objetos e procure por imagens grandes, transparência, sombras, animações e multimídia; atribua uma pontuação de complexidade aproximada para identificar possíveis gargalos de desempenho.