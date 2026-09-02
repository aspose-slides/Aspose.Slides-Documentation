---
title: Recuperar e Atualizar Informações da Apresentação no Android
linktitle: Informações da Apresentação
type: docs
weight: 30
url: /pt/androidjava/examine-presentation/
keywords:
- formato de apresentação
- propriedades da apresentação
- propriedades de documento
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

Este artigo mostra como inspecionar informações de apresentação no Aspose.Slides. Ele explica como determinar o formato atual de uma apresentação sem carregar o arquivo completo, ler suas propriedades de documento e atualizar essas propriedades quando necessário.

Os exemplos são baseados nas APIs [PresentationInfo](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/documentproperties/) e demonstram operações típicas para trabalhar com metadados de apresentação.

## **Verificar o formato de uma apresentação**

Antes de trabalhar em uma apresentação, talvez você queira descobrir em qual formato (PPT, PPTX, ODP e outros) a apresentação está no momento.

É possível verificar o formato de uma apresentação sem carregá‑la. Veja este código Java:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Obter propriedades da apresentação**

Este código Java mostra como obter as propriedades da apresentação (informações sobre a apresentação):

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

Talvez você queira ver as [propriedades sob a classe DocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--).

## **Atualizar propriedades da apresentação**

Aspose.Slides fornece o método [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) que permite fazer alterações nas propriedades da apresentação.

Suponha que tenhamos uma apresentação PowerPoint com as propriedades de documento mostradas abaixo.

![Propriedades de documento originais da apresentação PowerPoint](input_properties.png)

Este exemplo de código mostra como editar algumas propriedades da apresentação:

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Os resultados da alteração das propriedades de documento são mostrados abaixo.

![Propriedades de documento alteradas da apresentação PowerPoint](output_properties.png)

## **Links úteis**

Para obter mais informações sobre uma apresentação e seus atributos de segurança, você pode achar estes links úteis:

- [Apresentações protegidas por senha](/slides/pt/androidjava/password-protected-presentation/)
- [Apresentações protegidas contra gravação](/slides/pt/androidjava/write-protected-presentation/)

## **Perguntas frequentes**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Procure por [informações de fontes incorporadas](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) no nível da apresentação, depois compare essas entradas com o conjunto de [fonts realmente usados no conteúdo](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsmanager/#getFonts--) para identificar quais fontes são críticas para a renderização.

**Como posso identificar rapidamente se o arquivo tem slides ocultos e quantos?**

Percorra a [coleção de slides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slidecollection/) e inspecione a [bandeira de visibilidade](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slide/#getHidden--) de cada slide.

**Posso detectar se um tamanho de slide e orientação personalizados estão sendo usados e se diferem dos padrões?**

Sim. Compare o [tamanho do slide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getSlideSize--) e a orientação atuais com os padrões predefinidos; isso ajuda a prever o comportamento ao imprimir e exportar.

**Existe uma maneira rápida de verificar se os gráficos referenciam fontes de dados externas?**

Sim. Percorra todos os [gráficos](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/chart/), verifique sua [fonte de dados](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) e observe se os dados são internos ou baseados em links, incluindo quaisquer links quebrados.

**Como posso avaliar slides 'pesados' que podem retardar a renderização ou a exportação para PDF?**

Para cada slide, contabilize a quantidade de objetos e procure por imagens grandes, transparência, sombras, animações e multimídia; atribua uma pontuação de complexidade aproximada para sinalizar possíveis pontos críticos de desempenho.