---
title: Por que não usar automação
type: docs
weight: 50
url: /pt/php-java/why-not-automation/
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
- PHP
- Aspose.Slides
description: "Descubra por que a automação do Office é arriscada para servidores e serviços, e veja como o Aspose.Slides oferece um processamento de apresentações mais seguro e rápido para PowerPoint e OpenDocument."
---
## **Visão geral**

Existem várias razões pelas quais os componentes Aspose são uma alternativa melhor à automação. Algumas das principais razões são:

- Segurança
- Estabilidade
- Escalabilidade/Velocidade
- Preço
- Recursos

A seguir, uma explicação mais detalhada de cada ponto-chave.

## **Perguntas importantes**

Existem duas perguntas que ouvimos com frequência na Aspose:

- Seus produtos precisam que o Microsoft Office esteja instalado para serem executados?

A resposta curta e simples é **NÃO**.

Os componentes Aspose são completamente independentes e não são afiliados, autorizados, patrocinados ou de outra forma aprovados pela Microsoft Corporation.

- Por que devemos usar produtos Aspose em vez da Automação do Microsoft Office?

Primeiro, há muitos [benefícios que você desfruta ao usar Aspose.Slides](/slides/pt/php-java/product-overview/).

Segundo, a própria Microsoft recomenda fortemente **aconselha contra** o uso da Automação do Office em soluções de software.

## **Segurança**

A seguir, uma citação direta de um artigo da Microsoft:

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."* 

Os produtos Aspose são muito seguros. Os componentes Aspose não representam risco potencial aos recursos críticos do sistema. Além disso, quando um documento é aberto por um componente Aspose, macros não são executadas automaticamente. Os componentes Aspose foram criados com o objetivo de permitir que desenvolvedores criem, manipulem e salvem arquivos do Office. Nenhum dos riscos associados ao pacote Microsoft Office é inerente aos componentes Aspose. 

## **Estabilidade**

A seguir, uma citação direta de um artigo da Microsoft:

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."* 

Os componentes Aspose foram amplamente testados e são extremamente estáveis. Os componentes Aspose são usados por [Companies](https://about.aspose.com/customers) como: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** e muitas, muitas outras. 

## **Escalabilidade/Velocidade**

A seguir, uma citação direta de um artigo da Microsoft:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.* 

Os componentes Aspose são altamente escaláveis e extremamente rápidos. Aplicações Office não foram projetadas para serem usadas simultaneamente por centenas ou milhares de usuários. Entretanto, os componentes Aspose foram criados exatamente para isso. Nossos componentes funcionam perfeitamente tanto em um servidor único, alimentando uma única aplicação, quanto em um Web Form balanceado que suporta uma aplicação corporativa completa. 

## **Preço**

Quando uma aplicação utiliza a Automação do Microsoft Office, é necessário adquirir uma cópia do Microsoft Office para cada máquina que executa a aplicação. Muitas vezes, uma aplicação precisa criar ou manipular um arquivo do Office sem que o usuário possua o Microsoft Office. A Aspose oferece uma licença muito [Custo‑efetivo](https://purchase.aspose.com/) e livre de royalties que permite implantação para número ilimitado de usuários sem preocupações de licenciamento. 

Ao criar aplicações web, é importante saber que os componentes de Automação do Microsoft Office não são precificados nem licenciados para soluções server‑side; portanto, não existe uma solução de licenciamento adequada para implantar aplicações web que utilizem esses componentes. A Aspose também oferece uma solução muito custo‑efetiva para aplicações baseadas em servidor. 

## **Recursos**

Os componentes Aspose fornecem tudo o que é necessário para gerenciar arquivos do Office e muito mais. Eles foram projetados com a filosofia de permitir que desenvolvedores alcancem os melhores resultados com o mínimo de esforço. Ao contrário da Automação do Office, os componentes Aspose oferecem muitas funções poderosas e que economizam tempo. Por exemplo, o [Aspose.Cells](https://products.aspose.com/cells/php-java/) permite que desenvolvedores importem dados de um **DataTable** ou **DataView** diretamente para um arquivo Excel. Cada [Every Component](https://products.aspose.com/total/php-java/) da família Aspose oferece seu próprio conjunto de recursos únicos e poderosos.

A melhor parte de adquirir um componente Aspose (ou suítes de componentes como o [Aspose.Total](https://products.aspose.com/total/php-java/)) é ter acesso às nossas equipes de desenvolvimento. Nossas equipes entendem que, se há um recurso que sua empresa precisa, provavelmente outras empresas também precisarão. Embora nem todo pedido de recurso possa ser implementado, nossas equipes procuram ser muito flexíveis e abertas ao oferecer assistência. Essa mentalidade ajudou os componentes Aspose a se tornarem tão poderosos. Se houver recursos adicionais que você precise dos objetos de Automação do Office, suas chances de vê‑los adicionados são muito, muito baixas. 

## **Conclusão**
{{% alert color="primary" %}} 

Embora este artigo tenha abordado muitos dos pontos principais que mostram por que os componentes Aspose são uma escolha melhor que a Automação do Office, há muitos, muitos mais. Este artigo foca apenas nos pontos mais relevantes. Todos os diferentes componentes Aspose oferecem uma [Versão de Avaliação](https://downloads.aspose.com/slides/pt/java) sem risco e sem obrigação. Encorajamos você a aproveitar essa avaliação para ver melhor o que a Aspose pode fazer por suas aplicações. 

{{% /alert %}}