---
title: Recuperar e Atualizar Informações de Apresentação no Android
linktitle: Informações da Apresentação
type: docs
weight: 30
url: /pt/androidjava/examine-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Explore slides, estrutura e metadados em apresentações PowerPoint e OpenDocument usando Java para obter insights mais rápidos e auditorias de conteúdo mais inteligentes."
---
## **Visão geral**

Este artigo mostra como inspecionar informações de apresentação no Aspose.Slides. Explica como determinar o formato atual de uma apresentação sem carregar o arquivo completo, ler suas propriedades de documento e atualizar essas propriedades quando necessário.

Os exemplos são baseados nas APIs [PresentationInfo](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/documentproperties/) e demonstram operações típicas para trabalhar com metadados de apresentação.

## **Verificar o formato de uma apresentação**

Antes de trabalhar em uma apresentação, pode ser útil descobrir em qual formato (PPT, PPTX, ODP e outros) a apresentação está no momento.

É possível verificar o formato de uma apresentação sem carregá‑la. Veja este código Java:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Obter propriedades da apresentação**

Este código Java mostra como obter propriedades da apresentação (informações sobre a apresentação):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

Você pode consultar as [propriedades em DocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) da classe.

## **Atualizar propriedades da apresentação**

Aspose.Slides fornece o método [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) que permite fazer alterações nas propriedades da apresentação.

Suponha que tenhamos uma apresentação PowerPoint com as propriedades de documento mostradas abaixo.

![Propriedades originais do documento da apresentação PowerPoint](input_properties.png)

Este exemplo de código mostra como editar algumas propriedades da apresentação:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Os resultados da alteração das propriedades de documento são mostrados abaixo.

![Propriedades alteradas do documento da apresentação PowerPoint](output_properties.png)

## **Links úteis**

Para obter mais informações sobre uma apresentação e seus atributos de segurança, estes links podem ser úteis:

- [Verificando se uma apresentação está criptografada](https://docs.aspose.com/slides/pt/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Verificando se uma apresentação está protegida contra gravação (somente leitura)](https://docs.aspose.com/slides/pt/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Verificando se uma apresentação está protegida por senha antes de carregá‑la](https://docs.aspose.com/slides/pt/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmando a senha usada para proteger uma apresentação](https://docs.aspose.com/slides/pt/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Procure por informações de [embedded-font](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) no nível da apresentação e compare essas entradas com o conjunto de [fonts actually used across content](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsmanager/#getFonts--) para identificar quais fontes são críticas para a renderização.

**Como posso saber rapidamente se o arquivo contém slides ocultos e quantos?**

Itere através da [slide collection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slidecollection/) e inspecione a [visibility flag](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slide/#getHidden--) de cada slide.

**Posso detectar se um tamanho e orientação de slide personalizados estão sendo usados e se diferem dos padrões?**

Sim. Compare o [slide size](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getSlideSize--) e a orientação atuais com as predefinições padrão; isso ajuda a prever o comportamento para impressão e exportação.

**Existe uma maneira rápida de ver se gráficos referenciam fontes de dados externas?**

Sim. Percorra todos os [charts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/chart/), verifique sua [data source](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) e observe se os dados são internos ou baseados em links, incluindo links quebrados.

**Como posso avaliar slides “pesados” que podem desacelerar a renderização ou exportação para PDF?**

Para cada slide, contabilize a quantidade de objetos e procure por imagens grandes, transparência, sombras, animações e multimídia; atribua uma pontuação de complexidade aproximada para sinalizar possíveis gargalos de desempenho.