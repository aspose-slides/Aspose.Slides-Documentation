---
title: 为何不使用自动化
type: docs
weight: 50
url: /zh/cpp/why-not-automation/
keywords:
- 自动化
- 微软 Office
- 比较
- 安全性
- 稳定性
- 可伸缩性
- 功能
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解为何 Office 自动化在服务器和服务中存在风险，并看看 Aspose.Slides 如何为 PowerPoint 和 OpenDocument 提供更安全、更快速的演示文稿处理。"
---
## **介绍**

Aspose 组件是自动化的更佳替代方案的原因有多方面。主要原因包括：

- 安全性
- 稳定性
- 可伸缩性/速度
- 成本
- 功能

以下是对每个关键点的更详细说明。

## **重要问题**
- 为什么 Aspose 组件远胜 Microsoft Office Automation？

我们在 Aspose 最常听到的两个问题是：

- 您的产品是否需要安装 Microsoft Office 才能运行？

简短的答案是 **否**。Aspose 及其组件完全独立，既不与微软公司关联，也未获得微软公司的授权、赞助或其他认可。

- 为什么我们应该使用 Aspose 产品而不是 Microsoft Office Automation？

我们能给出的最简答复是，有许多原因，其中最重要的一点是 *Microsoft 本身强烈建议不要在软件解决方案中使用 Office Automation： [Microsoft Article

## **安全性**
以下内容直接摘自上述 Microsoft 文章：

*"Office 应用程序从未设计用于服务器端使用，因此未考虑分布式组件面临的安全问题。Office 不会对传入请求进行身份验证，也不能防止您在服务器端代码中意外运行宏，或启动可能运行宏的其他服务器。不要打开来自匿名 Web 上传到服务器的文件！根据上次设置的安全配置，服务器可能在管理员或系统上下文中以完整权限运行宏，从而危及您的网络！此外，Office 使用许多客户端组件（如 Simple MAPI、WinInet、MSDAIPP），这些组件会缓存客户端身份验证信息以加快处理速度。如果在服务器端对 Office 进行自动化，一个实例可能为多个客户端提供服务，并且由于该会话的身份验证信息已被缓存，可能导致一个客户端使用另一个客户端的缓存凭据，从而通过冒充其他用户获得未授权的访问权限。*

Aspose 产品非常安全。因此，Aspose 组件不会对关键系统资源构成潜在风险。此外，当文档被 Aspose 组件打开时，宏不会自动运行。Aspose 组件的目标是帮助开发者创建、操作和保存 Office 文件。与 Microsoft Office 套件相关的风险并不存在于 Aspose 组件中。

## **稳定性**
以下内容直接摘自上述 Microsoft 文章：

*"Office 2000、Office XP 和 Office 2003 使用 Microsoft Windows Installer（MSI）技术，以简化终端用户的安装和自修复。MSI 引入了“首次使用时安装”的概念，允许在运行时动态安装或配置功能（针对系统，或更常见的是针对特定用户）。在服务器端环境中，这既会降低性能，又会增加出现对话框要求用户批准安装或提供相应安装光盘的可能性。虽然该机制旨在提升 Office 作为终端用户产品的弹性，但 Office 对 MSI 功能的实现却在服务器端环境中适得其反。此外，Office 整体的稳定性在服务器端运行时无法得到保证，因为它并未针对这种使用场景设计或测试。将 Office 作为网络服务器上的服务组件可能会降低该机器的稳定性，进而影响整个网络的稳定性。如果您计划在服务器端自动化 Office，请尝试将程序隔离到一台专用计算机上，该计算机不会影响关键功能，并且可以根据需要重启。*

由于 Aspose 组件打包为单个 DLL，永远不需要安装任何额外部件即可工作。Aspose 组件仅由 C++ 应用程序使用，且组件代码中没有需要人工响应的部分。Aspose 组件经过充分测试，极其稳定。Aspose 组件已被 [公司](https://about.aspose.com/customers) 如 **IBM**、**Hilton**、**Reader's Digest**、**Bank of America** 等众多企业使用。

## **可伸缩性/速度**
以下内容直接摘自上述 Microsoft 文章：

*"服务器端组件需要高度可重入、支持多线程的 COM 组件，具备最小开销并能为多个客户端提供高吞吐量。而 Office 应用程序在几乎所有方面恰恰相反。它们是非可重入、基于 STA 的自动化服务器，旨在为单个客户端提供多样但资源密集的功能。作为服务器端解决方案，它们几乎没有可伸缩性，并且在诸如内存等关键元素上存在固定限制，无法通过配置进行更改。更重要的是，它们使用全局资源（例如内存映射文件、全局加载项或模板以及共享自动化服务器），这会限制并发运行的实例数量，并在多客户端环境中配置时导致竞争条件。计划同时运行多个 Office 应用实例的开发者需要考虑对 Office 应用进行池化或串行访问，以避免潜在的死锁或数据损坏”。*

Aspose 组件具备高度可伸缩性且速度极快。Office 应用并非为数百甚至数千用户同时使用而设计。而 Aspose 组件正是为此而生。我们的组件是真正的 C++ 解决方案，无论是在单台服务器上为单一应用供能，还是在负载均衡的 Web 表单中为企业级应用提供服务，都能表现出色。

## **价格**
当应用程序使用 Microsoft Office Automation 时，必须为每台运行该应用的机器购买一份 Microsoft Office。很多情况下，应用需要创建或操作 Office 文件，却并不要求用户拥有 Microsoft Office。Aspose 提供极具[性价比](https://purchase.aspose.com/)且免版税的再分发许可，允许在无限数量的用户上部署，无需担心许可问题。创建基于 Web 的应用时，需要了解 Microsoft Office Automation 组件并未针对服务器端解决方案定价或授权；因此，使用 Microsoft Office 组件的 Web 应用没有合适的许可方案。Aspose 也为服务器端应用提供极具[性价比](https://purchase.aspose.com/)的解决方案。

## **功能**
Aspose 组件提供管理 Office 文件所需的一切功能，并且远超这些。它们的设计理念是让开发者以最少的工作量实现最大的成果。与 Office Automation 不同，Aspose 组件提供了许多强大且省时的功能。例如，[Aspose.Cells](https://products.aspose.com/cells/cpp/) 让开发者能够直接将 **DataTable** 或 **DataView** 的数据导入 Excel 文件。[Aspose.Words](https://products.aspose.com/words/net/) 提供类似的功能，允许开发者直接从任何 C++ 数据对象填充 Word（邮件合并）文档。[每个组件](https://products.aspose.com/total/cpp/) 在 Aspose 系列中都有其独特且强大的功能。购买 Aspose 组件的最大优势是可以获取我们的开发团队支持。我们的团队深知，若贵公司需要的某项功能，其他公司很可能也有同样需求。虽然并非所有功能请求都能被实现，但我们的团队在提供帮助时始终保持开放和灵活的态度。这种思维方式使得 Aspose 组件变得如此强大。如果您希望在 Office Automation 对象中获得额外功能，获得实现的可能性极低。

## **结论**
{{% alert color="info" %}} 

虽然本文已覆盖了 Aspose 组件相比 Office Automation 更佳选择的许多关键点，但实际还有更多。本篇文章仅重点阐述了最关键的要点。所有 Aspose 组件均提供免费、无义务的[评估版](https://downloads.aspose.com/slides/zh/cpp)。我们鼓励您利用该[评估版](https://downloads.aspose.com/slides/zh/cpp) 更深入了解 Aspose 能为您的应用实现的功能。

{{% /alert %}}