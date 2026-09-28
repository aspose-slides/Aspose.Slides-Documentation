---
title: Por que não usar Automação
type: docs
weight: 170
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

Existem várias razões pelas quais os componentes Aspose são uma alternativa melhor à automação. Algumas das razões principais são:

- Segurança
- Estabilidade
- Escalabilidade/Desempenho
- Preço
- Recursos

Abaixo está uma explicação mais detalhada de cada ponto chave.

## **Perguntas Importantes**

Existem duas perguntas que frequentemente ouvimos na Aspose:

- Seus produtos requerem que o Microsoft Office esteja instalado para serem executados?

A resposta curta e simples é **NÃO**.

Os componentes Aspose são completamente independentes e não são afiliados, autorizados, patrocinados ou de outra forma aprovados pela Microsoft Corporation.

- Por que devemos usar produtos Aspose em vez da Automação do Microsoft Office?

Primeiro, há muitos [benefícios que você desfruta ao usar Aspose.Slides](/slides/pt/net/product-overview/).

Segundo, a própria Microsoft recomenda fortemente **aconselha contra** a Automação do Office em soluções de software.

## **Segurança**
A seguir, uma citação direta de um artigo da Microsoft:

> "Os aplicativos do Office nunca foram projetados para uso em servidor e, portanto, não levam em consideração os problemas de segurança enfrentados por componentes distribuídos. O Office não autentica solicitações recebidas e não protege você de executar macros inadvertidamente ou iniciar outro servidor que possa executar macros a partir do seu código do lado do servidor. Não abra arquivos que são enviados para o servidor a partir de um site anônimo! Com base nas configurações de segurança definidas pela última vez, o servidor pode executar macros sob um contexto de Administrador ou Sistema com privilégios totais e comprometer sua rede! Além disso, o Office usa muitos componentes do lado do cliente (como Simple MAPI, WinInet, MSDAIPP) que podem armazenar em cache informações de autenticação do cliente para acelerar o processamento. Se o Office estiver sendo automatizado no lado do servidor, uma instância pode atender a mais de um cliente e, como as informações de autenticação foram armazenadas em cache para essa sessão, é possível que um cliente use as credenciais em cache de outro cliente, obtendo assim permissões de acesso não concedidas ao se passar por outros usuários."

Os produtos Aspose são muito **seguros**. Os componentes Aspose são executados no mesmo contexto de usuário que todas as aplicações ASP.NET (sob o usuário ASPNET). Portanto, os componentes Aspose **não** representam um risco de segurança. Eles também não consomem recursos críticos do sistema. Além disso, quando um componente Aspose abre um documento, as macros não são executadas automaticamente. Os componentes Aspose foram criados para permitir que os desenvolvedores criem, manipulem e salvem arquivos Office.

{{% alert color="info" title="Note" %}}
Nenhum dos riscos associados ao pacote Microsoft Office se aplica aos componentes Aspose.
{{% /alert %}}

## **Estabilidade**
Este texto é uma citação direta do artigo da Microsoft mencionado anteriormente:

> "Office 2000, Office XP e Office 2003 utilizam a tecnologia Microsoft Windows Installer (MSI) para facilitar a instalação e a autorreparo para o usuário final. O MSI introduz o conceito de \"instalar no primeiro uso\", que permite que recursos sejam instalados ou configurados dinamicamente em tempo de execução (para o sistema ou, mais frequentemente, para um usuário específico). Em um ambiente de servidor, isso tanto diminui o desempenho quanto aumenta a probabilidade de que uma caixa de diálogo apareça solicitando que o usuário aprove a instalação ou forneça um disco de instalação adequado. Embora seja projetado para aumentar a resiliência do Office como um produto para o usuário final, a implementação das capacidades do MSI pelo Office é contraproducente em um ambiente de servidor. Além disso, a estabilidade do Office em geral não pode ser garantida quando executado no lado do servidor, pois não foi projetado ou testado para esse tipo de uso. Usar o Office como um componente de serviço em um servidor de rede pode reduzir a estabilidade dessa máquina e, consequentemente, toda a sua rede. Se você planeja automatizar o Office no lado do servidor, tente isolar o programa em um computador dedicado que não possa afetar funções críticas e que possa ser reiniciado conforme necessário."

Como os componentes Aspose são empacotados em um único DLL, seus usuários nunca precisam instalar partes ou peças adicionais para que eles funcionem. Os componentes Aspose são utilizados apenas por aplicações .NET e não há nenhuma parte do código do componente projetada para aguardar uma resposta humana.

{{% alert color="info" title="Note" %}}
Os componentes Aspose foram testados extensivamente e confirmados como muito estáveis. Os componentes Aspose são usados por [empresas](https://about.aspose.com/customers/) como **Bank of America** e muitas outras organizações líderes em diversos setores e áreas.
{{% /alert %}}

## **Escalabilidade/Desempenho**
A seguir, uma citação direta de um artigo da Microsoft:

> "Componentes do lado do servidor precisam ser altamente reentrantes, componentes COM multithread com overhead mínimo e alta taxa de transferência para vários clientes. Os aplicativos do Office são, em quase todos os aspectos, o exato oposto. Eles são servidores de Automação não reentrantes baseados em STA, projetados para fornecer funcionalidade diversa, porém intensiva em recursos, para um único cliente. Eles oferecem pouca escalabilidade como solução de servidor e têm limites fixos para elementos importantes, como memória, que não podem ser alterados por configuração. Mais importante, eles utilizam recursos globais (como arquivos mapeados em memória, add-ins ou modelos globais e servidores de Automação compartilhados), o que pode limitar o número de instâncias que podem ser executadas simultaneamente e levar a condições de corrida se configurados em um ambiente multi-cliente. Desenvolvedores que pretendem executar mais de uma instância de qualquer aplicativo do Office ao mesmo tempo precisam considerar o Pooling ou a Serialização de Acesso ao Aplicativo do Office para evitar possíveis deadlocks ou corrupção de dados."

Os componentes Aspose são incrivelmente escaláveis e extremamente rápidos. Os aplicativos do Office não foram projetados para serem usados simultaneamente por centenas ou milhares de usuários, mas os componentes Aspose foram projetados exatamente para isso. Nossos componentes são uma verdadeira solução .NET.

{{% alert color="info" title="Note" %}}
O desempenho dos componentes Aspose é impecável em um único servidor (alimentando uma única aplicação) ou em um formulário web balanceado (alimentando uma aplicação em toda a empresa).
{{% /alert %}}

## **Preço**
Quando uma aplicação utiliza a Automação do Microsoft Office, é necessário adquirir uma cópia do Microsoft Office para cada máquina que executa a aplicação. Existem muitas situações em que uma aplicação pode precisar criar ou manipular um arquivo Office, mas o processo não requer o Microsoft Office.

{{% alert color="info" title="Note" %}}
A Aspose oferece uma licença de redistribuição muito [custo‑efetiva](https://purchase.aspose.com/) e livre de royalties que permite a implantação para um número ilimitado de usuários sem preocupações de licenciamento.
{{% /alert %}}

Ao criar aplicações baseadas na web, é importante lembrar que os componentes de Automação do Microsoft Office não são precificados nem licenciados para soluções de servidor. Portanto, não existe uma solução de licenciamento adequada para a implantação de aplicações web que utilizam componentes do Microsoft Office. A Aspose, por outro lado, oferece uma solução muito [custo‑efetiva](https://purchase.aspose.com/) para aplicações baseadas em servidor também.

## **Recursos**
Os componentes Aspose fornecem tudo o que é necessário para gerenciar arquivos Office e muito mais. Nós os projetamos com base em nossa filosofia de ajudar desenvolvedores a alcançar os melhores resultados possíveis com o mínimo de esforço.

{{% alert color="info" title="Note" %}}
Ao contrário da Automação do Office, os componentes Aspose oferecem muitas funções poderosas e que economizam tempo.
{{% /alert %}}

Por exemplo, [Aspose.Cells](https://products.aspose.com/cells/net/) permite que os desenvolvedores importem dados de um **DataTable** ou **DataView** diretamente para um arquivo Excel. [Aspose.Words](https://products.aspose.com/words/net/) oferece um recurso similar que permite que os desenvolvedores preencham um documento Word (ou seja, Mala Direta) diretamente a partir de qualquer objeto de dados .NET. [Cada componente](https://products.aspose.com/total/net/) da família Aspose oferece seu próprio conjunto de recursos únicos e poderosos.

A melhor parte de adquirir um componente Aspose é ter acesso às nossas equipes de desenvolvimento. Por exemplo, se você usa objetos de Automação do Office e precisa de determinados recursos, as chances de que esses recursos sejam adicionados são muito, muito baixas. No entanto, as coisas são diferentes com os componentes Aspose.

{{% alert color="info" title="Note" %}}
Nossas equipes de desenvolvimento entendem que se há um recurso que sua empresa precisa, há uma boa chance de que outras empresas precisem do mesmo recurso. Embora saibamos que não podemos implementar todos os recursos solicitados, nos esforçamos para adicionar o máximo de recursos possível com base no feedback dos nossos clientes.
{{% /alert %}}

Nossas equipes estão sempre abertas e flexíveis ao prestar assistência — e essa é a razão pela qual os componentes Aspose evoluíram para se tornarem tão poderosos como são hoje.

## **Conclusão**
{{% alert color="info" title="Note" %}}
Embora este artigo tenha abordado alguns dos pontos principais que explicam por que os componentes Aspose são uma escolha melhor que a Automação do Office, você deve entender que existem muitos, muitos outros benefícios. Nós abordamos apenas algumas das principais vantagens.

Além disso, todos os produtos e componentes Aspose oferecem uma [Versão de Avaliação](https://releases.aspose.com/slides/pt/net/) sem riscos e sem obrigação. Incentivamos você a aproveitar a avaliação para ver o que a Aspose pode fazer por suas aplicações ou negócios.
{{% /alert %}}