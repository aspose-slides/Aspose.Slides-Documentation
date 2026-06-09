---
title: Por que Não Automatizar
type: docs
weight: 50
url: /pt/cpp/why-not-automation/
keywords:
- automação
- Microsoft Office
- comparando
- segurança
- estabilidade
- escalabilidade
- recursos
- PowerPoint
- OpenDocument
- apresentação
- C++
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

Abaixo segue uma explicação mais detalhada de cada ponto chave.

## **Perguntas Importantes**
- Por que os componentes Aspose são uma opção muito melhor que a Automação do Microsoft Office?

Existem duas perguntas que ouvimos com mais frequência aqui na Aspose :

- Seus produtos exigem que o Microsoft Office esteja instalado para que eles funcionem?

A resposta curta e simples é **NÃO**. Aspose e os componentes Aspose são totalmente independentes e não são afiliados, nem autorizados, patrocinados ou aprovados pela Microsoft Corporation.

- Por que devemos usar produtos Aspose em vez de utilizar a Automação do Microsoft Office?

A resposta mais curta que podemos dar é que há muitas razões, sendo a principal que *o próprio Microsoft recomenda fortemente contra a Automação do Office a partir de soluções de software*: [Microsoft Article

## **Segurança**
A seguir, uma citação direta do artigo da Microsoft referenciado acima:  
*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

Os produtos Aspose são muito seguros. Portanto, os componentes Aspose não representam risco potencial aos recursos críticos do sistema. Além disso, quando um documento é aberto por um componente Aspose, macros não são executadas automaticamente. Os componentes Aspose foram criados com o objetivo de permitir que desenvolvedores criem, manipulem e salvem arquivos Office. Nenhum dos riscos associados ao pacote Microsoft Office é inerente aos componentes Aspose.

## **Estabilidade**
A seguir, uma citação direta do artigo da Microsoft referenciado acima:  
*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

Como os componentes Aspose são empacotados em um único DLL, nunca será necessário instalar partes ou peças adicionais para que funcionem. Os componentes Aspose são usados apenas por aplicações C++ e não há nenhuma parte do código do componente que aguarde uma resposta humana. Os componentes Aspose foram amplamente testados e são extremamente estáveis. Os componentes Aspose são usados por [Empresas](https://about.aspose.com/customers) como **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** e muitas, muitas mais.

## **Escalabilidade/Velocidade**
A seguir, uma citação direta do artigo da Microsoft referenciado acima:  

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

Os componentes Aspose são altamente escaláveis e extremamente rápidos. Aplicações Office não foram projetadas para serem usadas simultaneamente por centenas ou milhares de usuários. No entanto, os componentes Aspose foram criados exatamente para isso. Nossos componentes são uma solução C++ verdadeira e funcionam perfeitamente tanto em um único servidor, alimentando uma única aplicação, quanto em um Web Form balanceado que suporta uma aplicação corporativa completa.

## **Preço**
Quando uma aplicação utiliza a Automação do Microsoft Office, uma cópia do Microsoft Office deve ser adquirida para cada máquina que executa a aplicação. Muitas vezes uma aplicação precisa criar ou manipular um arquivo Office sem exigir que o usuário possua o Microsoft Office. A Aspose oferece uma licença muito [Custo‑benefício](https://purchase.aspose.com/) e livre de royalties que permite a implantação para um número ilimitado de usuários sem preocupações de licenciamento. Ao criar aplicações web, é importante saber que os componentes de Automação do Microsoft Office não têm preço nem licença para soluções server‑side; portanto, não existe uma solução de licenciamento adequada para implantar aplicações web que utilizem esses componentes. A Aspose oferece uma solução muito [Custo‑benefício](https://purchase.aspose.com/) para aplicações server‑side também.

## **Recursos**
Os componentes Aspose fornecem tudo o que é necessário para gerenciar arquivos Office e muito mais. Eles foram projetados com a filosofia de permitir que desenvolvedores alcancem os melhores resultados com o menor esforço. Diferente da Automação Office, os componentes Aspose oferecem muitas funções poderosas e que economizam tempo. Por exemplo, [Aspose.Cells](https://products.aspose.com/cells/cpp/) permite aos desenvolvedores importar dados de um **DataTable** ou **DataView** diretamente para um arquivo Excel. [Aspose.Words](https://products.aspose.com/words/net/) oferece recurso semelhante que permite popular um documento Word (mail merge) diretamente a partir de qualquer objeto de dados C++. [Every Component](https://products.aspose.com/total/cpp/) da família Aspose oferece seu próprio conjunto de recursos únicos e poderosos. A melhor parte de adquirir um componente Aspose é ter acesso às nossas equipes de desenvolvimento. Nossas equipes percebem que, se houver um recurso que sua empresa precise, muito provavelmente outras empresas também precisarão. Embora nem toda solicitação de recurso possa ser atendida, nossas equipes são bastante abertas e flexíveis ao prestar assistência. Essa mentalidade ajudou os componentes Aspose a se tornarem tão poderosos. Se houver recursos adicionais que você precise dos objetos de Automação Office, suas chances de vê‑los adicionados são muito, muito baixas.

## **Conclusão**
{{% alert color="primary" %}} 

Embora este artigo tenha abordado muitos dos pontos principais que tornam os componentes Aspose uma escolha melhor que a Automação Office, há muitos, muitos mais. Este artigo trata principalmente dos pontos mais críticos. Todos os diferentes componentes Aspose oferecem uma [Versão de Avaliação](https://downloads.aspose.com/slides/pt/cpp) sem risco e sem obrigação. Incentivamos você a aproveitar essa [Versão de Avaliação](https://downloads.aspose.com/slides/pt/cpp) para ver melhor o que a Aspose pode fazer pelas suas aplicações.