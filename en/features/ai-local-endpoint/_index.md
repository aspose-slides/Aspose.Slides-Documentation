---
title: Connect a self-hosted AI endpoint
description: Use a self-hosted OpenAI-compatible endpoint for library AI calls.
type: docs
url: /features/ai-local-endpoint/
weight: 1540
feature_id: ai-local-endpoint
feature_group: ai
translationKey: slides-feature-ai-local-endpoint
feature_catalogue_version: 2
feature_guides:
- /slides/net/ai/
---

## **Overview**

Point the library's compatible AI client at a model endpoint running on infrastructure you control. The Slides workflow sends its requests to that endpoint, which can be local to the application or on your own network. The model service is supplied and managed separately.

## **FAQ**

**Does the Slides library include an offline language model?**

No. You provide the model server. Compatibility depends on the endpoint and on the model returning the response structure the workflow expects.

## **Guides**

- [AI Features in Aspose.Slides (.NET)](/slides/net/ai/)

Related feature: [Connect your own AI model provider](/slides/features/ai-model-provider/).
