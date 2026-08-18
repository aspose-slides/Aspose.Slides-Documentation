---
title: Clonar Slides de Apresentação em C++
linktitle: Clonar Slides
type: docs
weight: 40
url: /pt/cpp/clone-slides/
keywords:
- clonar slide
- copiar slide
- salvar slide
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Duplique rapidamente slides do PowerPoint com Aspose.Slides para C++. Siga nossos claros exemplos de código para automatizar a criação de PPT em segundos e eliminar o trabalho manual."
---
## **Introdução**

Clonar é o processo de fazer uma cópia exata ou réplica de algo. O Aspose.Slides for C++ também possibilita fazer uma cópia ou clone de qualquer slide e então inserir esse slide clonado na apresentação atual ou em qualquer outra apresentação aberta. O processo de clonagem de slide cria um novo slide que pode ser modificado pelos desenvolvedores sem alterar o slide original. Existem várias maneiras possíveis de clonar um slide:

- Clonar ao final dentro de uma apresentação.
- Clonar em outra posição dentro da apresentação.
- Clonar ao final em outra apresentação.
- Clonar em outra posição em outra apresentação.
- Clonar em posição específica em outra apresentação.

No Aspose.Slides for C++, (uma coleção de [ISlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/) objetos) exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) fornece os métodos [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) e [InsertClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/insertclone/) para realizar os tipos de clonagem de slide acima.

## **Clonar um Slide ao Final de uma Apresentação**
Se você quiser clonar um slide e então usá‑lo dentro do mesmo arquivo de apresentação ao final dos slides existentes, use o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) de acordo com os passos listados abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
2. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) referenciando a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
3. Chame o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) e passe o slide a ser clonado como parâmetro para o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) .
4. Grave o arquivo de apresentação modificado.

No exemplo abaixo, clonamos um slide (situado na primeira posição – índice zero – da apresentação) para o final da apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Clonar um Slide para outra Posição dentro de uma Apresentação**
Se você quiser clonar um slide e então usá‑lo dentro do mesmo arquivo de apresentação, mas em outra posição, use o método [InsertClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/insertclone/) :

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
2. Instancie a classe referenciando a coleção **Slides** exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
3. Chame o método [InsertClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/insertclone/) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) e passe o slide a ser clonado juntamente com o índice para a nova posição como parâmetro para o método [InsertClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/insertclone/) .
4. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, clonamos um slide (situado no índice zero – posição 1 – da apresentação) para o índice 1 – Posição 2 – da apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Clonar um Slide ao Final de outra Apresentação**
Se precisar clonar um slide de uma apresentação e usá‑lo em outro arquivo de apresentação, ao final dos slides existentes:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) que contém a apresentação de onde o slide será clonado.
2. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) que contém a apresentação de destino para a qual o slide será adicionado.
3. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) referenciando a coleção **Slides** exposta pelo objeto Presentation da apresentação de destino.
4. Chame o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) e passe o slide da apresentação de origem como parâmetro para o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) .
5. Grave o arquivo da apresentação de destino modificada.

No exemplo abaixo, clonamos um slide (do primeiro índice da apresentação de origem) para o final da apresentação de destino.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Clonar um Slide para outra Posição em outra Apresentação**
Se precisar clonar um slide de uma apresentação e usá‑lo em outro arquivo de apresentação, em uma posição específica:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) que contém a apresentação de origem da qual o slide será clonado.
2. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) que contém a apresentação à qual o slide será adicionado.
3. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) referenciando a coleção Slides exposta pelo objeto Presentation da apresentação de destino.
4. Chame o método [InsertClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/insertclone/) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) e passe o slide da apresentação de origem juntamente com a posição desejada como parâmetro para o método [InsertClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/insertclone/) .
5. Grave o arquivo da apresentação de destino modificada.

No exemplo abaixo, clonamos um slide (do índice zero da apresentação de origem) para o índice 1 (posição 2) da apresentação de destino.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Clonar um Slide em uma Posição Específica em outra Apresentação**
Se precisar clonar um slide com slide mestre de uma apresentação e usá‑lo em outra apresentação, primeiro é necessário clonar o slide mestre desejado da apresentação de origem para a apresentação de destino. Em seguida, use esse slide mestre para clonar o slide com mestre. O método **AddClone(ISlide, IMasterSlide)** espera o slide mestre da apresentação de destino, e não da apresentação de origem. Para clonar o slide com mestre, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) que contém a apresentação de origem da qual o slide será clonado.
2. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) que contém a apresentação de destino para a qual o slide será clonado.
3. Acesse o slide a ser clonado juntamente com o slide mestre.
4. Instancie a classe [IMasterSlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslidecollection/) referenciando a coleção Masters exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) da apresentação de destino.
5. Chame o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) exposto pelo objeto [IMasterSlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslidecollection/) e passe o mestre do PPTX de origem a ser clonado como parâmetro para o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) .
6. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) definindo a referência para a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) da apresentação de destino.
7. Chame o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) e passe o slide da apresentação de origem a ser clonado e o slide mestre como parâmetro para o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) .
8. Grave o arquivo da apresentação de destino modificada.

No exemplo abaixo, clonamos um slide com mestre (situado no índice zero da apresentação de origem) para o final da apresentação de destino usando o mestre do slide de origem.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Clonar um Slide ao Final de uma Seção Especificada**
Se você quiser clonar um slide e então usá‑lo dentro do mesmo arquivo de apresentação, mas em uma seção diferente, use o método [**AddClone()**](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) exposto pela interface [**ISlideCollection**](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) . O Aspose.Slides for C++ possibilita clonar um slide da primeira seção e inserir esse slide clonado na segunda seção da mesma apresentação.

O trecho de código a seguir mostra como clonar um slide e inserir o slide clonado em uma seção especificada.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Garantir Tamanho de Slide Correspondente**

Ao clonar slides para outra apresentação, certifique‑se de que a apresentação de destino tenha o mesmo tamanho de slide da origem. Se os tamanhos dos slides forem diferentes, o Aspose.Slides não redimensiona automaticamente as formas clonadas—suas coordenadas e dimensões originais são preservadas, o que pode fazer com que o conteúdo pareça desalinhado ou ultrapasse os limites do slide.

Você pode definir o tamanho de slide da apresentação de destino para corresponder ao da origem antes de clonar o mestre e o slide:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

Faça isso antes de clonar o mestre e o slide.

## **FAQ**

**As notas do apresentador e os comentários dos revisores são clonados?**

Sim. A página de notas e os comentários de revisão são incluídos na cópia. Se não quiser mantê‑los, [remova‑os](/slides/pt/cpp/presentation-notes/) após a inserção.

**Como os gráficos e suas fontes de dados são tratados?**

O objeto do gráfico, sua formatação e os dados incorporados são copiados. Se o gráfico estava vinculado a uma fonte externa (por exemplo, uma pasta de trabalho OLE incorporada), esse vínculo é preservado como um [objeto OLE](/slides/pt/cpp/manage-ole/). Após mover entre arquivos, verifique a disponibilidade dos dados e o comportamento de atualização.

**Posso controlar a posição de inserção e as seções do clone?**

Sim. Você pode inserir o clone em um índice de slide específico e colocá‑lo em uma [seção](/slides/pt/cpp/slide-section/) escolhida. Se a seção de destino não existir, crie‑a primeiro e então mova o slide para ela.