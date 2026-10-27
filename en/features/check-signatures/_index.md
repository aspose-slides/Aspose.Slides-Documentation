---
title: Check presentation signatures
description: Inspect presentation signature validity and certificate details.
type: docs
url: /features/check-signatures/
weight: 1340
feature_id: check-signatures
feature_group: security
translationKey: slides-feature-check-signatures
feature_catalogue_version: 2
feature_guides:
- /slides/net/digital-signature-in-powerpoint/
---

## **Overview**

Read a presentation's signatures and inspect their validity status, certificate metadata, signing time and comments. This helps an application display the signature information exposed by the library. Use the result within the signature format's documented scope.

## **FAQ**

**Does a valid result establish trust in the signer?**

No. Certificate trust-chain checking is separate. Signature coverage also has format and document-part limitations, so validity does not imply that every part was signed.

## **Guides**

- [Add Digital Signatures to Presentations in .NET](/slides/net/digital-signature-in-powerpoint/)

Related feature: [Sign presentations digitally](/slides/features/digital-signatures/).
