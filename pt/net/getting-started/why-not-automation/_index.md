---
title: Por que não usar automação
type: docs
weight: 40
url: /pt/net/why-not-automation/
keywords:
- automação
- Microsoft Office
- comparação
- segurança
- estabilidade
- escalabilidade
- recursos
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Descubra por que a automação do Office é arriscada para servidores e serviços, e veja como o Aspose.Slides oferece processamento de apresentações mais seguro e rápido para PowerPoint e OpenDocument."
---
## **Introdução**

Existem várias razões pelas quais os componentes Aspose são uma alternativa melhor à automação. Algumas das principais razões são:

- Segurança
- Estabilidade
- Escalabilidade/Velocidade
- Preço
- Recursos

Abaixo está uma explicação mais detalhada de cada ponto chave.

## **Perguntas Importantes**

Existem duas perguntas que frequentemente ouvimos na Aspose:

- Seus produtos requerem a instalação do Microsoft Office para serem executados?

A resposta curta e simples é **NÃO**.

- Por que devemos usar os produtos Aspose em vez da Automação do Microsoft Office?

Primeiro, há muitos [benefícios que você desfruta ao usar Aspose.Slides](/slides/pt/net/product-overview/).

Segundo, a própria Microsoft recomenda fortemente **não utilizar** a Automação do Office em soluções de software.

## **Segurança**
A seguir, uma citação direta de um artigo da Microsoft: 

> "Os aplicativos do Office nunca foram projetados para uso no servidor, e, portanto, não consideram os problemas de segurança enfrentados por componentes distribuídos. O Office não autentica solicitações recebidas e não protege você de executar macros inadvertidamente ou de iniciar outro servidor que possa executar macros a partir do seu código no servidor. Não abra arquivos que são enviados ao servidor a partir de uma Web anônima! Com base nas configurações de segurança que foram definidas pela última vez, o servidor pode executar macros sob o contexto de Administrador ou Sistema com privilégios completos e comprometer sua rede! Além disso, o Office usa muitos componentes cliente (como Simple MAPI, WinInet, MSDAIPP) que podem armazenar em cache informações de autenticação do cliente para acelerar o processamento. Se o Office estiver sendo automatizado no servidor, uma instância pode atender mais de um cliente e, como as informações de autenticação foram armazenadas em cache para essa sessão, é possível que um cliente use as credenciais em cache de outro cliente, obtendo assim permissões de acesso não concedidas ao se passar por outros usuários."

Os produtos Aspose são muito **seguros**. Os componentes Aspose executam no mesmo contexto de usuário que todas as aplicações ASP.NET (sob o usuário ASPNET). Portanto, os componentes Aspose **não** representam um risco de segurança. Eles também não consomem recursos críticos do sistema. Além disso, quando um componente Aspose abre um documento, as macros não são executadas automaticamente. Os componentes Aspose foram criados para permitir que os desenvolvedores criem, manipulem e salvem arquivos do Office.

{{% alert color="primary" %}} 
Nenhum dos riscos associados ao pacote Microsoft Office se aplica aos componentes Aspose.
{{% /alert %}} 

## **Estabilidade**
Este texto é uma citação direta do artigo da Microsoft mencionado anteriormente: 

> "Office 2000, Office XP e Office 2003 utilizam a tecnologia Microsoft Windows Installer (MSI) para facilitar a instalação e a autorreparação para o usuário final. O MSI introduz o conceito de \"instalar no primeiro uso\", que permite que recursos sejam instalados ou configurados dinamicamente em tempo de execução (para o sistema ou, mais frequentemente, para um usuário específico). Em um ambiente de servidor, isso tanto diminui o desempenho quanto aumenta a probabilidade de aparecer uma caixa de diálogo pedindo ao usuário que aprove a instalação ou forneça um disco de instalação adequado. Embora seja projetado para aumentar a resiliência do Office como produto para usuários finais, a implementação das capacidades do MSI pelo Office é contraproducente em um ambiente de servidor. Além disso, a estabilidade do Office em geral não pode ser garantida quando executado no servidor, pois não foi projetado ou testado para esse tipo de uso. Usar o Office como componente de serviço em um servidor de rede pode reduzir a estabilidade dessa máquina e, como consequência, de toda a sua rede. Se você planeja automatizar o Office no servidor, tente isolar o programa em um computador dedicado que não possa afetar funções críticas e que possa ser reiniciado conforme necessário."

Como os componentes Aspose são empacotados em um único DLL, seus usuários nunca precisam instalar partes ou peças adicionais para que funcionem. Os componentes Aspose são utilizados apenas por aplicações .NET e não há nenhuma parte do código do componente projetada para aguardar uma resposta humana.

{{% alert color="primary" %}} 
Os componentes Aspose foram rigorosamente testados e confirmados como muito estáveis. Os componentes Aspose são usados por [empresas](http://www.aspose.com/Corporate/Aspose/Customerlist.html) como **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, e muitas outras organizações líderes em vários setores e áreas. 
{{% /alert %}} 

## **Escalabilidade/Velocidade**
A seguir, uma citação direta de um artigo da Microsoft: 

> "Componentes do lado do servidor precisam ser componentes COM altamente reentrantes, multi‑threaded, com overhead mínimo e alta taxa de transferência para múltiplos clientes. Os aplicativos do Office são, em quase todos os aspectos, exatamente o oposto. Eles são servidores de Automação baseados em STA, não reentrantes, projetados para fornecer funcionalidades diversas, porém intensivas em recursos, para um único cliente. Eles oferecem pouca escalabilidade como solução de servidor e têm limites fixos para elementos importantes, como memória, que não podem ser alterados por configuração. Mais importante ainda, eles utilizam recursos globais (como arquivos mapeados na memória, complementos ou modelos globais e servidores de Automação compartilhados), o que pode limitar o número de instâncias que podem ser executadas simultaneamente e causar condições de corrida se configurados em um ambiente multi‑cliente. Desenvolvedores que planejam executar mais de uma instância de qualquer aplicativo Office ao mesmo tempo precisam considerar o pool ou a serialização de acesso ao aplicativo Office para evitar possíveis deadlocks ou corrupção de dados."

Os componentes Aspose são incrivelmente escaláveis e extremamente rápidos. Os aplicativos do Office não foram projetados para serem usados simultaneamente por centenas ou milhares de usuários, mas os componentes Aspose foram projetados exatamente para isso. Nossos componentes são uma solução .NET verdadeira.

{{% alert color="primary" %}} 
O desempenho dos componentes Aspose é impecável em um único servidor (alimentando uma única aplicação) ou em um formulário web balanceado (alimentando uma aplicação em toda a empresa).
{{% /alert %}} 

## **Preço**
Quando uma aplicação utiliza a Automação do Microsoft Office, uma cópia do Microsoft Office deve ser comprada para cada máquina que executa a aplicação. Existem muitas situações em que uma aplicação pode precisar criar ou manipular um arquivo Office, mas o processo não requer o Microsoft Office.

{{% alert color="primary" %}} 
Aspose fornece uma licença de redistribuição muito [custo‑efetiva](https://purchase.aspose.com/) e livre de royalties que permite a implantação para um número ilimitado de usuários sem preocupações de licenciamento. 
{{% /alert %}} 

Ao criar aplicações baseadas na web, é importante lembrar que os componentes de Automação do Microsoft Office não têm preço nem licença para soluções de servidor. Portanto, não há uma solução de licenciamento adequada para a implantação de aplicações web que utilizam componentes do Microsoft Office. A Aspose, por outro lado, oferece uma solução muito [custo‑efetiva](https://purchase.aspose.com/) para aplicações baseadas em servidor também.

## **Recursos**
Os componentes Aspose fornecem tudo o que é necessário para gerenciar arquivos Office e muito mais. Nós os projetamos com base em nossa filosofia de ajudar desenvolvedores a alcançar os maiores resultados possíveis com o menor esforço.

{{% alert color="primary" %}} 
Diferentemente da Automação do Office, os componentes Aspose oferecem muitas funções poderosas e que economizam tempo. 
{{% /alert %}} 

Por exemplo, o [Aspose.Cells](https://products.aspose.com/cells/net/) oferece aos desenvolvedores a capacidade de importar dados de uma **DataTable** ou **DataView** diretamente para um arquivo Excel. O [Aspose.Words](https://products.aspose.com/words/net/) fornece um recurso semelhante que permite aos desenvolvedores preencher um documento Word (ou seja, Mala Direta) diretamente a partir de qualquer objeto de dados .NET. [Cada componente](https://products.aspose.com/total/net/) na família Aspose oferece seu próprio conjunto de recursos únicos e poderosos.

A melhor parte de adquirir um componente Aspose é ter acesso às nossas equipes de desenvolvimento. Por exemplo, se você usa objetos de Automação do Office e precisa de determinados recursos, as chances de esses recursos serem adicionados são muito, muito baixas. No entanto, as coisas são diferentes com os componentes Aspose.

{{% alert color="primary" %}} 
Nossas equipes de desenvolvimento entendem que, se houver um recurso que sua empresa precisa, há uma boa chance de que outras empresas precisem do mesmo recurso. Embora saibamos que não podemos implementar todas as solicitações, nos esforçamos para adicionar o maior número possível de recursos com base no feedback de nossos clientes. 
{{% /alert %}} 

Nossas equipes estão sempre abertas e flexíveis ao oferecer assistência — e esse é o motivo pelo qual os componentes Aspose cresceram e se tornaram tão poderosos como são hoje.

## **Conclusão**
{{% alert color="primary" %}} 
Embora este artigo tenha abordado alguns dos pontos chave sobre por que os componentes Aspose são uma escolha melhor que a Automação do Office, você precisa entender que há muitos, muitos outros benefícios. Nós apenas abordamos algumas das principais vantagens. 

Além disso, todos os produtos e componentes Aspose oferecem uma [Versão de Avaliação](https://downloads.aspose.com/slides/pt/net) sem risco e sem obrigação. Incentivamos você a aproveitar a avaliação para ver o que a Aspose pode fazer pelas suas aplicações ou negócios. 
{{% /alert %}}