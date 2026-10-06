---
title: Por que não usar Automação
type: docs
weight: 170
url: /pt/java/why-not-automation/
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
- Java
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

Existem duas perguntas que ouvimos com frequência na Aspose:

- Seus produtos exigem que o Microsoft Office esteja instalado para serem executados?

A resposta curta e simples é **NÃO**.

Os componentes Aspose são completamente independentes e não são afiliados, autorizados, patrocinados ou aprovações de forma alguma pela Microsoft Corporation.

- Por que devemos usar produtos Aspose em vez da automação do Microsoft Office?

Primeiro, há muitos [benefícios que você obtém ao usar Aspose.Slides](/slides/pt/java/product-overview/).

Segundo, a própria Microsoft **aconselha fortemente contra** o uso da automação do Office em soluções de software.

## **Segurança**

A seguir, uma citação direta de um artigo da Microsoft:

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*


Os produtos Aspose são muito seguros. Os componentes Aspose não representam risco potencial aos recursos críticos do sistema. Além disso, quando um documento é aberto por um componente Aspose, macros não são executadas automaticamente. Os componentes Aspose foram criados com o objetivo de permitir que desenvolvedores criem, manipulem e salvem arquivos do Office. Nenhum dos riscos associados ao pacote Microsoft Office é inerente aos componentes Aspose.

## **Estabilidade**
A seguir, uma citação direta de um artigo da Microsoft:

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*


Os componentes Aspose foram testados exaustivamente e são extremamente estáveis. Os componentes Aspose são usados por [empresas](https://about.aspose.com/customers/) como **Bank of America** e muitas outras.

## **Escalabilidade/Velocidade**
A seguir, uma citação direta de um artigo da Microsoft:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.*


Os componentes Aspose são altamente escaláveis e extremamente rápidos. Aplicações Office não foram projetadas para serem usadas simultaneamente por centenas ou milhares de usuários. No entanto, os componentes Aspose foram desenvolvidos exatamente para isso. Nossos componentes funcionam perfeitamente tanto em um único servidor, alimentando uma única aplicação, quanto em um farm de servidores web balanceados que suportam uma aplicação corporativa de grande escala.

## **Preço**
Quando uma aplicação utiliza a Automação do Microsoft Office, é necessário adquirir uma cópia do Microsoft Office para cada máquina que executa a aplicação. Muitas vezes, uma aplicação precisa criar ou manipular um arquivo Office sem exigir que o usuário tenha o Microsoft Office instalado. A Aspose oferece uma licença **custo‑efetiva** e livre de royalties que permite a implantação para um número ilimitado de usuários sem preocupações de licenciamento.

Ao criar aplicações baseadas na web, é importante saber que os componentes de Automação do Microsoft Office não são precificados nem licenciados para soluções server‑side; portanto, não há uma solução de licenciamento adequada para implantar aplicações web que utilizem os componentes Microsoft Office. A Aspose oferece uma solução muito custo‑efetiva para aplicações server‑side também.

## **Recursos**
Os componentes Aspose fornecem tudo o que é necessário para gerenciar arquivos Office e muito mais. Eles foram projetados com a filosofia de permitir que desenvolvedores alcancem os melhores resultados com o mínimo de esforço. Diferentemente da Automação Office, os componentes Aspose oferecem muitas funções poderosas e que economizam tempo. Por exemplo, [Aspose.Cells](https://products.aspose.com/cells/java/) permite que desenvolvedores importem dados de um **DataTable** ou **DataView** diretamente para um arquivo Excel. [Aspose.Words](https://products.aspose.com/words/java/) oferece um recurso semelhante que permite aos desenvolvedores preencher um documento Word (mesmo que Mail Merge). [Cada Componente](https://products.aspose.com/total/java/) da família Aspose oferece seu próprio conjunto de recursos únicos e poderosos.

A melhor parte de adquirir um componente Aspose (ou suites de componentes como [Aspose.Total](https://products.aspose.com/total/java/)) é ter acesso às nossas equipes de desenvolvimento. Nossas equipes reconhecem que, se existe um recurso que sua empresa precisa, é provável que outras empresas também o precisem. Embora nem todas as solicitações de recursos possam ser atendidas, nossas equipes procuram ser muito abertas e flexíveis ao prestar assistência. Essa mentalidade tem ajudado os componentes Aspose a se tornarem tão poderosos. Se houver recursos adicionais que você precise dos objetos de Automação Office, suas chances de vê‑los adicionados são muito, muito baixas.

## **Conclusão**
{{% alert color="info" title="Note" %}}

Embora este artigo tenha abordado muitos dos pontos chave que tornam os componentes Aspose uma escolha melhor que a Automação Office, há muitos, muitos mais. Este artigo trata principalmente dos pontos mais relevantes. Todos os diferentes componentes Aspose oferecem uma [Versão de Avaliação](https://releases.aspose.com/slides/pt/java/) sem risco e sem obrigação. Incentivamos você a aproveitar essa Avaliação para ver melhor o que a Aspose pode fazer por suas aplicações.

{{% /alert %}}