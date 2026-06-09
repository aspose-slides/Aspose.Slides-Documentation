---
title: "Clonar Slides de Apresentação em C++"
linktitle: "Clonar Slides"
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
description: "Duplique rapidamente slides do PowerPoint com Aspose.Slides para C++. Siga nossos exemplos de código claros para automatizar a criação de PPT em segundos e eliminar o trabalho manual."
---
## **Introdução**

Clonar é o processo de fazer uma cópia exata ou réplica de algo. Aspose.Slides for C++ também permite fazer uma cópia ou clone de qualquer slide e então inserir esse slide clonado na apresentação atual ou em qualquer outra aberta. O processo de clonagem de slides cria um novo slide que pode ser modificado pelos desenvolvedores sem alterar o slide original. Existem várias maneiras possíveis de clonar um slide:

- Clonar no final dentro de uma apresentação.
- Clonar em outra posição dentro da apresentação.
- Clonar no final em outra apresentação.
- Clonar em outra posição em outra apresentação.
- Clonar em posição específica em outra apresentação.

Em Aspose.Slides for C++, (uma coleção de [ISlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/) objects) exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) fornece os métodos [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) e [InsertClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/insertclone/) para executar os tipos de clonagem de slides acima.

## **Clonar um Slide no Final de uma Apresentação**
Se você deseja clonar um slide e então usá‑lo dentro do mesmo arquivo de apresentação no final dos slides existentes, use o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) conforme os passos listados abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
2. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) referenciando a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
3. Chame o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) e passe o slide a ser clonado como parâmetro para o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) .
4. Grave o arquivo de apresentação modificado.

No exemplo abaixo, clonamos um slide (situado na primeira posição – índice zero – da apresentação) para o final da apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Clonar um Slide para Outra Posição dentro de uma Apresentação**
Se você deseja clonar um slide e então usá‑lo dentro do mesmo arquivo de apresentação, mas em uma posição diferente, use o método [InsertClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/insertclone/) :

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
2. Instancie a classe referenciando a coleção **Slides** exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
3. Chame o método [InsertClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/insertclone/) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) e passe o slide a ser clonado junto com o índice para a nova posição como parâmetro para o método [InsertClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/insertclone/) .
4. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, clonamos um slide (situado no índice zero – posição 1 – da apresentação) para o índice 1 – Posição 2 – da apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Clonar um Slide no Final de Outra Apresentação**
Se você precisar clonar um slide de uma apresentação e usá‑lo em outra apresentação, no final dos slides existentes:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) contendo a apresentação da qual o slide será clonado.
2. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) contendo a apresentação de destino à qual o slide será adicionado.
3. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) referenciando a coleção **Slides** exposta pelo objeto Presentation da apresentação de destino.
4. Chame o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) e passe o slide da apresentação de origem como parâmetro para o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) .
5. Grave o arquivo da apresentação de destino modificada.

No exemplo abaixo, clonamos um slide (do primeiro índice da apresentação de origem) para o final da apresentação de destino.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Clonar um Slide para Outra Posição em Outra Apresentação**
Se você precisar clonar um slide de uma apresentação e usá‑lo em outra apresentação, em uma posição específica:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) contendo a apresentação de origem da qual o slide será clonado.
2. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) contendo a apresentação à qual o slide será adicionado.
3. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) referenciando a coleção Slides exposta pelo objeto Presentation da apresentação de destino.
4. Chame o método [InsertClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/insertclone/) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) e passe o slide da apresentação de origem junto com a posição desejada como parâmetro para o método [InsertClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/insertclone/) .
5. Grave o arquivo da apresentação de destino modificada.

No exemplo abaixo, clonamos um slide (do índice zero da apresentação de origem) para o índice 1 (posição 2) da apresentação de destino.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Clonar um Slide em Posição Específica em Outra Apresentação**
Se você precisar clonar um slide com slide mestre de uma apresentação e usá‑lo em outra apresentação, primeiro deve clonar o slide mestre desejado da apresentação de origem para a apresentação de destino. Em seguida, use esse slide mestre para clonar o slide com mestre. O método **AddClone(ISlide, IMasterSlide)** espera o slide mestre da apresentação de destino, e não da apresentação de origem. Para clonar o slide com mestre, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) contendo a apresentação de origem da qual o slide será clonado.
2. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) contendo a apresentação de destino para a qual o slide será clonado.
3. Acesse o slide a ser clonado junto com o slide mestre.
4. Instancie a classe [IMasterSlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslidecollection/) referenciando a coleção Masters exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) da apresentação de destino.
5. Chame o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) exposto pelo objeto [IMasterSlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslidecollection/) e passe o mestre do PPTX de origem a ser clonado como parâmetro para o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) .
6. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) definindo a referência para a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) da apresentação de destino.
7. Chame o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) e passe o slide da apresentação de origem a ser clonado e o slide mestre como parâmetros para o método [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) .
8. Grave o arquivo da apresentação de destino modificada.

No exemplo abaixo, clonamos um slide com mestre (situado no índice zero da apresentação de origem) para o final da apresentação de destino usando o mestre do slide de origem.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Clonar um Slide no Final de uma Seção Especificada**
Se você deseja clonar um slide e então usá‑lo dentro do mesmo arquivo de apresentação, mas em uma seção diferente, use o método [**AddClone()**](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) exposto pela interface [**ISlideCollection**](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/). Aspose.Slides for C++ permite clonar um slide da primeira seção e então inserir esse slide clonado na segunda seção da mesma apresentação.

O trecho de código a seguir mostra como clonar um slide e inserir o slide clonado em uma seção especificada.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **FAQ**

**As notas do orador e os comentários do revisor são clonados?**

Sim. A página de notas e os comentários de revisão são incluídos no clone. Se você não quiser eles, [remova‑os](/slides/pt/cpp/presentation-notes/) após a inserção.

**Como os gráficos e suas fontes de dados são tratados?**

O objeto do gráfico, a formatação e os dados incorporados são copiados. Se o gráfico estava vinculado a uma fonte externa (por exemplo, uma pasta de trabalho OLE incorporada), esse vínculo é mantido como um [objeto OLE](/slides/pt/cpp/manage-ole/). Após mover entre arquivos, verifique a disponibilidade dos dados e o comportamento de atualização.

**Posso controlar a posição de inserção e as seções do clone?**

Sim. Você pode inserir o clone em um índice de slide específico e posicioná‑lo em uma [seção](/slides/pt/cpp/slide-section/) escolhida. Se a seção de destino não existir, crie‑a primeiro e então mova o slide para ela.